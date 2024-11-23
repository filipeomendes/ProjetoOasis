# Global Solution - Projeto Oasis 

Uma iniciativa revolucionária que transforma a energia solar do deserto do Saara em soluções sustentáveis para o mundo, através da produção e distribuição de hidrogênio verde. Nossa plataforma conecta produtores e consumidores, promovendo um futuro mais limpo e renovável para todos.

## Integrantes do Grupo

- Fernando Paparelli Aracena (RM551022)
- Filipe de Oliveira Mendes (RM98959)
- Miron Gonçalves Martins (RM551801)
- Victor Luca do Nascimento Queiroz (RM551886)
- Vinicius Pedro de Souza (RM550907)

## Descrição 

### Visão Geral

O Projeto Oasis é uma solução inovadora para o aproveitamento sustentável da energia solar disponível no deserto do Saara. Utilizando tecnologia de ponta, o projeto transforma a energia solar em hidrogênio e oxigênio por meio de um processo chamado eletrólise. Esses gases, altamente versáteis e limpos, são armazenados em barris ou cilindros, permitindo fácil transporte e uso em diversas indústrias e aplicações.

Por meio de um aplicativo dedicado, o Projeto Oasis conecta produtores de hidrogênio e oxigênio a consumidores, sejam eles empresas ou indivíduos, promovendo a substituição de combustíveis fósseis e contribuindo para a redução da pegada de carbono global.

### O Que é Eletrólise?

A eletrólise é o processo químico que utiliza eletricidade para dividir a água (H₂O) em seus dois componentes principais: hidrogênio (H₂) e oxigênio (O₂). Para isso, aplica-se uma corrente elétrica em um recipiente contendo água e um eletrólito, separando os gases.

- **Hidrogênio (H₂):** Pode ser usado como combustível em veículos, geração de energia ou processos industriais, sendo uma alternativa limpa aos combustíveis fósseis.
- **Oxigênio (O₂):** Pode ser usado em diversas áreas, incluindo a indústria médica e processos industriais.

### Por Que o Saara?

O deserto do Saara é um dos locais mais ensolarados do mundo, recebendo radiação solar suficiente para gerar energia em larga escala. Essa energia é essencial para alimentar o processo de eletrólise e produzir hidrogênio verde, um combustível sustentável.

Além disso, o transporte direto de eletricidade do Saara para outras regiões seria inviável devido à perda de energia ao longo das longas distâncias. Transformar a energia solar em hidrogênio facilita seu armazenamento e transporte em cilindros ou barris, permitindo que ela alcance mercados globais com eficiência.

### Nosso Projeto

O aplicativo do Projeto Oasis conecta produtores de hidrogênio e oxigênio a consumidores que buscam alternativas limpas de energia. Ele permite:

- **Busca e compra de hidrogênio e oxigênio** em diferentes formatos
- **Conexão entre produtores e consumidores**, promovendo um mercado sustentável
- **Gestão de pedidos e logística**, facilitando o transporte dos produtos

### Benefícios do Projeto

- **Sustentabilidade:** Redução da emissão de gases do efeito estufa ao substituir combustíveis fósseis por hidrogênio verde
- **Inovação:** Transformação da energia solar em produtos de alta demanda e valor
- **Impacto Global:** Contribuição para o futuro energético limpo e renovável do planeta

O Projeto Oasis é mais do que uma ideia; é um passo em direção a um mundo mais sustentável e conectado. Seja parte dessa revolução energética!

## Documentação da API

## Credenciais Auth Login

- username: filipe
- password: 1234

### Endpoints da API

#### Produtos Controller

##### GET /api/Produtos
Retorna todos os produtos cadastrados no sistema.

**Exemplo de Requisição (Swagger)**:
```
GET /api/Produtos
```

**Exemplo de Resposta**:
```json
[
    {
        "id": 1,
        "nome": "Exclusivo Oxigênio Eficiente Natural",
        "preco": 155.00,
        "categoria": "Hidrogênio Gasoso",
        "quantidadeVendida": 1100,
        "litros": null,
        "impactoAmbiental": 6.1,
        "origem": "Nacional"
    },
    {
        "id": 2,
        "nome": "Exclusivo Hidrogênio Puro Natural",
        "preco": 216.00,
        "categoria": "Oxigênio Líquido",
        "quantidadeVendida": 1170,
        "litros": 81.2,
        "impactoAmbiental": 6.44,
        "origem": "Internacional"
    }
]
```

##### GET /api/Produtos/{id}
Retorna um produto específico pelo ID.

**Exemplo de Requisição (Swagger)**:
```
GET /api/Produtos/1
```

**Exemplo de Resposta**:
```json
{
    "id": 1,
    "nome": "Exclusivo Oxigênio Eficiente Natural",
    "preco": 155.00,
    "categoria": "Hidrogênio Gasoso",
    "quantidadeVendida": 1100,
    "litros": null,
    "impactoAmbiental": 6.1,
    "origem": "Nacional"
}
```

##### POST /api/Produtos
Cadastra um novo produto no sistema.

**Exemplo de Requisição (Swagger)**:
```json
POST /api/Produtos
{
    "nome": "Super Hidrogênio Puro Verde",
    "preco": 256.00,
    "categoria": "Oxigênio Gasoso",
    "quantidadeVendida": 453,
    "litros": null,
    "impactoAmbiental": 0.45,
    "origem": "Nacional"
}
```

**Exemplo de Resposta**:
```json
{
    "id": 3,
    "nome": "Super Hidrogênio Puro Verde",
    "preco": 256.00,
    "categoria": "Oxigênio Gasoso",
    "quantidadeVendida": 453,
    "litros": null,
    "impactoAmbiental": 0.45,
    "origem": "Nacional"
}
```

##### PUT /api/Produtos/{id}
Atualiza um produto existente.

**Exemplo de Requisição (Swagger)**:
```json
PUT /api/Produtos/3
{
    "id": 3,
    "nome": "Super Hidrogênio Puro Verde Premium",
    "preco": 299.00,
    "categoria": "Oxigênio Gasoso",
    "quantidadeVendida": 453,
    "litros": null,
    "impactoAmbiental": 0.45,
    "origem": "Nacional"
}
```

**Resposta**: 204 No Content

##### DELETE /api/Produtos/{id}
Remove um produto do sistema.

**Exemplo de Requisição (Swagger)**:
```
DELETE /api/Produtos/3
```

**Resposta**: 204 No Content

#### Previsão de Impacto Ambiental Controller

##### POST /api/PrevisaoImpactoAmbiental/prever
Realiza a previsão do impacto ambiental de um produto usando Machine Learning.

**Exemplo de Requisição (Swagger)**:
```json
POST /api/PrevisaoImpactoAmbiental/prever
{
    "nomeProduto": "Hiper Hidrogênio Puro Eficiente",
    "categoria": "Hidrogênio Gasoso",
    "preco": 203.0,
    "quantidadeVendida": 1585,
    "origem": "Importado Especial",
    "litros": null
}
```

**Exemplo de Resposta**:
```json
{
    "impactoAmbiental": 7.89
}
```

### Modelo de Machine Learning

#### Visão Geral
O sistema utiliza Machine Learning para prever o impacto ambiental dos produtos em uma escala de 0 a 10.

#### Características Utilizadas
- Nome do produto
- Categoria (Hidrogênio Gasoso, Oxigênio Líquido, etc.)
- Preço
- Quantidade vendida
- Origem (Nacional, Internacional, Importado Especial)
- Volume em litros (quando aplicável)

#### Escala de Impacto
- 0: menor impacto ambiental possível
- 10: maior impacto ambiental possível

#### Especificações Técnicas
- Algoritmo: FastForest Regression
- Número de árvores: 100
- Mínimo de exemplos por folha: 10
- Normalização de dados numéricos
- Codificação one-hot para dados categóricos

### Guia de Implementação

#### Como Testar no Swagger
1. Execute a aplicação
2. Acesse o Swagger UI em `/swagger`
3. Expanda o endpoint desejado clicando nele
4. Clique em "Try it out"
5. Preencha os parâmetros necessários
6. Clique em "Execute"
7. Observe a resposta na seção "Responses"

#### Fluxo de Teste Completo
1. Crie um novo produto (POST /api/Produtos)
2. Obtenha a previsão de impacto (POST /api/PrevisaoImpactoAmbiental/prever)
3. Atualize o produto com o impacto previsto (PUT /api/Produtos/{id})
4. Verifique o produto atualizado (GET /api/Produtos/{id})

#### Requisitos do Sistema
- Arquivo de treinamento: `/Data/dados_treinamento.csv`
- Modelo treinado: `/wwwroot/MLModels/ModeloImpactoAmbiental.zip`

#### Notas Importantes
- O modelo é treinado automaticamente na primeira execução
- Todas as previsões são normalizadas entre 0 e 10
- O sistema requer dados de treinamento válidos para funcionamento correto


### Cliente Controller

#### Modelo de Dados

##### Cliente

#### Endpoints da API

##### GET /api/Clientes
Retorna todos os clientes cadastrados no sistema.

**Exemplo de Requisição (Swagger)**:
```
GET /api/Clientes
```

**Exemplo de Resposta**:
```json
[
    {
        "id": 1,
        "nome": "Empresa Verde Sustentável",
        "cpfCnpj": "12345678000199",
        "endereco": "Av. Sustentabilidade, 123",
        "telefone": "11999887766",
        "email": "contato@empresaverde.com",
        "segmentoCliente": "Indústria"
    },
    {
        "id": 2,
        "nome": "João Silva",
        "cpfCnpj": "12345678900",
        "endereco": "Rua das Flores, 456",
        "telefone": "11988776655",
        "email": "joao.silva@email.com",
        "segmentoCliente": "Pessoa Física"
    }
]
```

##### GET /api/Clientes/{id}
Retorna um cliente específico pelo ID.

**Exemplo de Requisição (Swagger)**:
```
GET /api/Clientes/1
```

**Exemplo de Resposta**:
```json
{
    "id": 1,
    "nome": "Empresa Verde Sustentável",
    "cpfCnpj": "12345678000199",
    "endereco": "Av. Sustentabilidade, 123",
    "telefone": "11999887766",
    "email": "contato@empresaverde.com",
    "segmentoCliente": "Indústria"
}
```

##### POST /api/Clientes
Cadastra um novo cliente no sistema.

**Exemplo de Requisição (Swagger)**:
```json
POST /api/Clientes
{
    "nome": "Eco Energia LTDA",
    "cpfCnpj": "98765432000188",
    "endereco": "Rua da Inovação, 789",
    "telefone": "11977665544",
    "email": "contato@ecoenergia.com",
    "segmentoCliente": "Distribuidor"
}
```

**Exemplo de Resposta**:
```json
{
    "id": 3,
    "nome": "Eco Energia LTDA",
    "cpfCnpj": "98765432000188",
    "endereco": "Rua da Inovação, 789",
    "telefone": "11977665544",
    "email": "contato@ecoenergia.com",
    "segmentoCliente": "Distribuidor"
}
```

##### PUT /api/Clientes/{id}
Atualiza um cliente existente.

**Exemplo de Requisição (Swagger)**:
```json
PUT /api/Clientes/3
{
    "id": 3,
    "nome": "Eco Energia Sustentável LTDA",
    "cpfCnpj": "98765432000188",
    "endereco": "Rua da Inovação, 789",
    "telefone": "11977665544",
    "email": "contato@ecoenergias.com",
    "segmentoCliente": "Distribuidor"
}
```

**Resposta**: 204 No Content

##### DELETE /api/Clientes/{id}
Remove um cliente do sistema.

**Exemplo de Requisição (Swagger)**:
```
DELETE /api/Clientes/3
```

**Resposta**: 204 No Content

#### Validações e Restrições

- **Nome**: Obrigatório, máximo 100 caracteres
- **CPF/CNPJ**: Obrigatório, máximo 14 caracteres (CPF: 11 dígitos, CNPJ: 14 dígitos)
- **Endereço**: Máximo 255 caracteres
- **Telefone**: Máximo 15 caracteres
- **Email**: Máximo 100 caracteres
- **Segmento Cliente**: Define o tipo/segmento do cliente (ex: Pessoa Física, Indústria, Distribuidor)

#### Como Testar no Swagger

1. Execute a aplicação
2. Acesse o Swagger UI em `/swagger`
3. Navegue até a seção de Clientes
4. Teste os endpoints:
   - Liste todos os clientes (GET)
   - Cadastre um novo cliente (POST)
   - Consulte um cliente específico (GET com ID)
   - Atualize dados de um cliente (PUT)
   - Remova um cliente (DELETE)

#### Fluxo de Teste Completo

1. Crie um novo cliente usando POST
2. Verifique se o cliente foi criado usando GET
3. Atualize algumas informações do cliente usando PUT
4. Confirme as alterações usando GET pelo ID
5. Se necessário, remova o cliente usando DELETE