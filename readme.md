# Customer Registration API

Este projeto é uma API RESTful desenvolvida em C# utilizando a plataforma .NET Core 8. A API permite o cadastro, listagem, edição e remoção das empresas. O projeto foi construído seguindo o padrão de arquitetura em camadas e os princípios do DDD (Domain Driven Design). Além disso, foi aplicado o padrão CQRS (Command Query Responsibility Segregation) para separar operações de escrita e leitura, aumentando a eficiência da aplicação.

## Funcionalidades
- Cadastro de clientes com os seguintes campos:
  - `id`: Identificador único.
  - `Nome da Empresa`: Nome da empresa cadastrada.
  - `Porte da Empresa`: Classificação do porte (Pequena, Média, Grande).
- Listagem de clientes cadastrados.
- Edição de clientes existentes.
- Remoção de clientes.

## Tecnologias Utilizadas
- **C#**
- **.NET Core 8**
- **Entity Framework** para mapeamento objeto-relacional (ORM).
- **Banco de dados relacional**: SQL Server.
- **MongoDB**: projeção de dados na camada de leitura (CQRS).

## Arquitetura
A aplicação segue os princípios do Domain Driven Design (DDD), dividindo a solução nas seguintes camadas:
1. **Camada de Apresentação (API)**: Exposição dos endpoints RESTful.
2. **Camada de Aplicação**: Contém as regras de negócios e a lógica de aplicação.
3. **Camada de Domínio**: Contém as entidades e regras de domínio.
4. **Camada de Acesso a Dados**: Integração com o banco de dados relacional e NoSQL.

## Requisitos
- .NET Core 5 ou superior.
- SQL Server, PostgreSQL ou MySQL.
- MongoDB (opcional, para projeção de dados no CQRS).

## Instruções para Execução
1. Clone o repositório.
2. Não há necessidade de executar nenhum comando de migration.
3. Inicie a API utilizando o comando `dotnet run`.
