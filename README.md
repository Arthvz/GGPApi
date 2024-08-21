# GGPApi

## Propósito
Este projeto é uma API para gerenciar usuários, receitas e despesas, permitindo a criação, consulta e cálculo de saldo e balanço mensal.

## Requisitos
- .NET 8.0 SDK
- Entity Framework Core

## Instalação
1. Clone o repositório: `git clone https://github.com/usuario/GGPApi.git`
2. Navegue até a pasta do projeto: `cd GGPApi`
3. Restaure os pacotes: `dotnet restore`
4. Execute a aplicação: `dotnet run`

## Utilização
### Endpoints
- `GET /api/user/{userId}/saldo`: Retorna o saldo total de um usuário.
- `GET /api/user/{userId}/balanco?month={month}&year={year}`: Retorna o balanço mensal de um usuário.

### Exemplos de uso
```bash
curl -X GET "https://localhost:5001/api/user/1/saldo"
curl -X GET "https://localhost:5001/api/user/1/balanco?month=8&year=2024"
