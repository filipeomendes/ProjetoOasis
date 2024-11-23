using Microsoft.AspNetCore.Mvc;
using Microsoft.ML.Data;
using Microsoft.ML;
using System.IO;
using System;

namespace ProjetoOasis.Controllers
{
    public class DadosProdutoRequest
    {
        public string NomeProduto { get; set; }
        public string Categoria { get; set; }
        public float Preco { get; set; }
        public float QuantidadeVendida { get; set; }
        public string Origem { get; set; }
        public float? Litros { get; set; }
    }

    public class DadosProdutoTreinamento
    {
        [LoadColumn(0)] public string NomeProduto { get; set; }
        [LoadColumn(1)] public string Categoria { get; set; }
        [LoadColumn(2)] public float Preco { get; set; }
        [LoadColumn(3)] public string Origem { get; set; }
        [LoadColumn(4)] public float QuantidadeVendida { get; set; }
        [LoadColumn(5)] public float Litros { get; set; }
        [LoadColumn(6)] public float ImpactoAmbiental { get; set; }
    }

    public class PrevisaoImpactoAmbiental
    {
        [ColumnName("Score")]
        public float ImpactoAmbiental { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PrevisaoImpactoAmbientalController : ControllerBase
    {
        private readonly string _caminhoModelo;
        private readonly string _caminhoTreinamento;
        private readonly MLContext _mlContext;

        public PrevisaoImpactoAmbientalController()
        {
            _mlContext = new MLContext(seed: 1);
            _caminhoModelo = Path.Combine(Environment.CurrentDirectory, "wwwroot", "MLModels", "ModeloImpactoAmbiental.zip");
            _caminhoTreinamento = Path.Combine(Environment.CurrentDirectory, "Data", "dados_treinamento.csv");

            var pastaModelo = Path.GetDirectoryName(_caminhoModelo);
            if (!Directory.Exists(pastaModelo))
            {
                Directory.CreateDirectory(pastaModelo);
            }

            if (!System.IO.File.Exists(_caminhoModelo))
            {
                TreinarModelo();
            }
        }

        private void TreinarModelo()
        {
            if (!System.IO.File.Exists(_caminhoTreinamento))
            {
                throw new FileNotFoundException($"Arquivo de treinamento não encontrado em: {_caminhoTreinamento}");
            }

            // Carrega os dados
            IDataView dadosTreinamento = _mlContext.Data.LoadFromTextFile<DadosProdutoTreinamento>(
                path: _caminhoTreinamento,
                hasHeader: true,
                separatorChar: ',',
                allowQuoting: true);  // Permite valores entre aspas

            // Define o pipeline de transformação
            var pipeline = _mlContext.Transforms
                .Categorical.OneHotEncoding(outputColumnName: "CategoriaEncoded", inputColumnName: nameof(DadosProdutoTreinamento.Categoria))
                .Append(_mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "OrigemEncoded", inputColumnName: nameof(DadosProdutoTreinamento.Origem)))
                .Append(_mlContext.Transforms.ReplaceMissingValues(
                    outputColumnName: nameof(DadosProdutoTreinamento.Litros),
                    inputColumnName: nameof(DadosProdutoTreinamento.Litros)))
                .Append(_mlContext.Transforms.NormalizeMinMax(nameof(DadosProdutoTreinamento.Preco)))
                .Append(_mlContext.Transforms.NormalizeMinMax(nameof(DadosProdutoTreinamento.QuantidadeVendida)))
                .Append(_mlContext.Transforms.NormalizeMinMax(nameof(DadosProdutoTreinamento.Litros)))
                .Append(_mlContext.Transforms.Concatenate("Features",
                    "CategoriaEncoded",
                    "OrigemEncoded",
                    nameof(DadosProdutoTreinamento.Preco),
                    nameof(DadosProdutoTreinamento.QuantidadeVendida),
                    nameof(DadosProdutoTreinamento.Litros)))
                .Append(_mlContext.Transforms.CopyColumns("Label", nameof(DadosProdutoTreinamento.ImpactoAmbiental)))
                .Append(_mlContext.Regression.Trainers.FastForest(numberOfTrees: 100, minimumExampleCountPerLeaf: 10));

            try
            {
                Console.WriteLine("Iniciando treinamento do modelo...");
                var modelo = pipeline.Fit(dadosTreinamento);
                Console.WriteLine("Modelo treinado com sucesso!");

                Console.WriteLine("Avaliando o modelo...");
                var predictions = modelo.Transform(dadosTreinamento);
                var metrics = _mlContext.Regression.Evaluate(predictions);

                Console.WriteLine($"R² Score: {metrics.RSquared:0.##}");
                Console.WriteLine($"Root Mean Squared Error: {metrics.RootMeanSquaredError:0.##}");

                Console.WriteLine("Salvando o modelo...");
                _mlContext.Model.Save(modelo, dadosTreinamento.Schema, _caminhoModelo);
                Console.WriteLine($"Modelo salvo em: {_caminhoModelo}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante o treinamento: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                throw;
            }
        }

        [HttpPost("prever")]
        public ActionResult<PrevisaoImpactoAmbiental> PreverImpactoAmbiental([FromBody] DadosProdutoRequest request)
        {
            try
            {
                if (!System.IO.File.Exists(_caminhoModelo))
                {
                    return BadRequest("Modelo não encontrado. Execute o treinamento primeiro.");
                }

                var dadosParaPrevisao = new DadosProdutoTreinamento
                {
                    NomeProduto = request.NomeProduto,
                    Categoria = request.Categoria,
                    Preco = request.Preco,
                    QuantidadeVendida = request.QuantidadeVendida,
                    Origem = request.Origem,
                    Litros = request.Litros ?? 0,
                    ImpactoAmbiental = 0
                };

                ITransformer modelo;
                using (var stream = new FileStream(_caminhoModelo, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    modelo = _mlContext.Model.Load(stream, out var modeloSchema);
                }

                var predictor = _mlContext.Model.CreatePredictionEngine<DadosProdutoTreinamento, PrevisaoImpactoAmbiental>(modelo);
                var resultado = predictor.Predict(dadosParaPrevisao);
                resultado.ImpactoAmbiental = Math.Max(0, Math.Min(10, resultado.ImpactoAmbiental));

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na previsão: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                return StatusCode(500, $"Erro ao fazer previsão: {ex.Message}");
            }
        }
    }
}