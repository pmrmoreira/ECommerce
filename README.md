# ECommerce API

Projeto de aprendizagem de .NET 8 Web API com arquitetura DDD (Domain-Driven Design).

## Tecnologias

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL (via Docker)
- Swagger / OpenAPI

## Estrutura do Projeto

```
ECommerce/
├── Controllers/        # Endpoints HTTP
├── Domain/
│   ├── Common/         # BaseEntity
│   ├── Entities/       # Product
│   ├── Exceptions/     # DomainException
│   └── ValueObjects/   # Money
├── Migrations/         # Migrações EF Core
├── Models/             # Requests (DTOs de entrada)
├── Persistence/        # DbContext e configurações EF Core
└── Services/           # Camada de aplicação (IProductService, ProductService)
```

## Como correr

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Passos

1. Arrancar a base de dados:

```bash
docker-compose up -d
```

2. Aplicar as migrações:

```bash
dotnet ef database update
```

3. Correr o projeto:

```bash
dotnet run
```

4. Abrir o Swagger em: `https://localhost:{porta}/swagger`

## Endpoints

| Método | Rota                  | Descrição                  |
|--------|-----------------------|----------------------------|
| GET    | /api/products         | Lista todos os produtos     |
| GET    | /api/products/{id}    | Busca produto por id        |
| POST   | /api/products         | Cria um novo produto        |
| POST   | /api/products/seed    | Popula com dados de exemplo |

## Roadmap

- [x] Domain Layer (Product, Money, DomainException)
- [x] Persistence (EF Core + PostgreSQL)
- [x] Service Layer (IProductService)
- [ ] DTOs de resposta
- [ ] Entidade Order
- [ ] Repository Pattern
- [ ] Autenticação JWT
- [ ] Tratamento de erros global
