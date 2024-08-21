# GGPApi

## Propósito
GGPApi é uma API construída com ASP.NET Core 8.0 que oferece funcionalidades para gerenciar usuários, receitas e despesas, e calcular balanços financeiros. A API é projetada para fornecer uma estrutura clara e escalável para o gerenciamento de finanças pessoais, permitindo a criação, edição, exclusão e consulta de dados financeiros.
Projeto criado para avaliação.

## Funcionalidades

- **Gestão de Usuários**: Criação, edição, exclusão e consulta de usuários.
- **Gestão de Receitas**: Criação, edição, exclusão e consulta de receitas financeiras.
- **Gestão de Despesas**: Criação, edição, exclusão e consulta de despesas financeiras.
- **Cálculo de Saldo**: Cálculo do saldo total de um usuário com base em suas receitas e despesas.
- **Cálculo de Balanço Mensal**: Cálculo do balanço financeiro mensal de um usuário para um mês e ano específicos.

## Requisitos

- .NET 8.0 SDK ou superior
- Entity Framework Core 8.0 ou superior

## Instalação
1. Clone o repositório: `git clone https://github.com/usuario/GGPApi.git`
2. Navegue até a pasta do projeto: `cd GGPApi`
3. Restaure os pacotes: `dotnet restore`
4. Execute a aplicação: `dotnet run`

## Utilização
### Endpoints
## UserController

- **Listar Usuários**: `GET /api/User/ListarUsers`  
  Retorna a lista de todos os usuários cadastrados.

- **Buscar Usuário por ID**: `GET /api/User/BuscarUserPorId/{idUser}`  
  Retorna os detalhes de um usuário específico pelo ID.

- **Buscar Usuário por ID de Despesa**: `GET /api/User/BuscarUserPorIdDespesa/{idDespesa}`  
  Retorna o usuário relacionado a uma despesa específica.

- **Buscar Usuário por ID de Receita**: `GET /api/User/BuscarUserPorIdReceita/{idReceita}`  
  Retorna o usuário relacionado a uma receita específica.

- **Criar Usuário**: `POST /api/User/CriarUser`  
  Cria um novo usuário com os dados fornecidos.

- **Editar Usuário**: `PUT /api/User/EditarUser`  
  Atualiza as informações de um usuário existente.

- **Deletar Usuário**: `DELETE /api/User/DeletarUser`  
  Remove um usuário do sistema.

## ReceitaController

- **Listar Receitas**: `GET /api/Receita/ListarReceitas`  
  Retorna a lista de todas as receitas cadastradas.

- **Buscar Receita por ID**: `GET /api/Receita/BuscarReceitaPorId/{idReceita}`  
  Retorna os detalhes de uma receita específica pelo ID.

- **Buscar Receitas por ID de Usuário**: `GET /api/Receita/BuscarReceitaPorIdUser/{idUser}`  
  Retorna todas as receitas associadas a um usuário específico.

- **Criar Receita**: `POST /api/Receita/CriarReceitas`  
  Adiciona uma nova receita ao sistema.

- **Editar Receita**: `PUT /api/Receita/EditarReceitas`  
  Atualiza as informações de uma receita existente.

- **Deletar Receita**: `DELETE /api/Receita/DeletarReceitas`  
  Remove uma receita do sistema.

## DespesaController

- **Listar Despesas**: `GET /api/Despesa/ListarDespesas`  
  Retorna a lista de todas as despesas cadastradas.

- **Buscar Despesa por ID**: `GET /api/Despesa/BuscarDespesasPorId/{idDespesa}`  
  Retorna os detalhes de uma despesa específica pelo ID.

- **Buscar Despesas por ID de Usuário**: `GET /api/Despesa/BuscarDespesasPorIdUser/{idUser}`  
  Retorna todas as despesas associadas a um usuário específico.

- **Criar Despesa**: `POST /api/Despesa/CriarDespesas`  
  Adiciona uma nova despesa ao sistema.

- **Editar Despesa**: `PUT /api/Despesa/EditarDespesas`  
  Atualiza as informações de uma despesa existente.

- **Deletar Despesa**: `DELETE /api/Despesa/DeletarDespesas`  
  Remove uma despesa do sistema.

## BalanceController

- **Calcular Saldo Total**: `GET /api/Balance/{userId}/saldo`  
  Calcula o saldo total de um usuário, subtraindo o total de despesas do total de receitas.

- **Calcular Balanço Mensal**: `GET /api/Balance/{userId}/balanco?month={month}&year={year}`  
  Calcula o balanço financeiro de um usuário para um mês e ano específicos.

## Tecnologias Utilizadas

- **ASP.NET Core 8.0**
- **Entity Framework Core 8.0**
- **InMemory Database**

## Como Contribuir

1. Faça um fork do projeto.
2. Crie uma nova branch: `git checkout -b minha-feature`.
3. Faça suas modificações e commit: `git commit -m 'Minha nova feature'`.
4. Envie para o seu fork: `git push origin minha-feature`.
5. Crie um pull request.
