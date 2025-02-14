# Developer Evaluation

This project is a full-stack application built with .NET 8.

## Prerequisites

- .NET SDK 8.0
- PostgreSQL


## Setup

1. Clone the repository
2. Update database connection string in `src/Ambev.DeveloperEvaluation.WebApi/appsettings.json`
3. Install dependencies:

```bash
# Backend
dotnet restore
```

## Database Migrations

To run the database migrations:

```bash
cd src/Ambev.DeveloperEvaluation.WebApi
dotnet ef database update
```


## Running the Application

### Backend API

```bash
cd src/Ambev.DeveloperEvaluation.WebApi
dotnet run
```
The API will be available at `http://0.0.0.0:5000`


### Docker Commands

1. Build Docker Image:
```bash
docker build -t myproject_image .
```

2. Run Docker Container:
```bash
docker run -d -p 5000:80 --name myproject_container myproject_image
```

3. Access the Application:
After running the container, access the Swagger documentation at:
```
http://localhost:5000/swagger/index.html
```


### Running Tests

```bash
# Run all tests
dotnet test

# Run specific test project
dotnet test tests/Ambev.DeveloperEvaluation.Unit/Ambev.DeveloperEvaluation.Unit.csproj

# Generate coverage report
./coverage-report.sh  # For Linux/Mac
coverage-report.bat   # For Windows
```

## API Documentation

The API documentation is available through Swagger at `http://0.0.0.0:5000/swagger`

1. Endpoints Principais:

   - **Autenticação**:
     - POST `/api/Auth` - Login no sistema
   
   - **Usuários**:
     - POST `/api/Users` - Criar novo usuário
     - GET `/api/Users/{id}` - Obter usuário por ID
     - DELETE `/api/Users/{id}` - Deletar usuário

   - **Produtos**:
     - POST `/api/Products` - Criar novo produto
     - GET `/api/Products/{id}` - Obter produto por ID

   - **Vendas**:
     - POST `/api/Sales` - Criar nova venda
     - GET `/api/Sales/{id}` - Obter venda por ID
     - PUT `/api/Sales/{id}` - Atualizar venda
     - DELETE `/api/Sales/{id}` - Deletar venda
     - POST `/api/Sales/{id}/cancel` - Cancelar venda

## Features

- User Authentication
- Product Management
- Sales Management
- Unit Tests
- Integration Tests
- API Documentation

## Project Architecture

- Clean Architecture
- CQRS Pattern
- Repository Pattern
- Domain-Driven Design
