# ECommerce API

Projeto de aprendizagem de .NET 8 Web API com arquitetura DDD (Domain-Driven Design).

## Tecnologias

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL (via Docker)
- Swagger / OpenAPI
- JWT Authentication
- BCrypt

## Estrutura do Projeto

```
ECommerce/
├── Controllers/        # Endpoints HTTP (Products, Orders, Auth)
├── Domain/
│   ├── Common/         # BaseEntity
│   ├── Entities/       # Product, Order, OrderItem, User
│   ├── Exceptions/     # DomainException
│   └── ValueObjects/   # Money
├── Middleware/         # Tratamento global de erros
├── Migrations/         # Migrações EF Core
├── Models/             # DTOs de entrada e saída
├── Persistence/
│   ├── Configurations/ # Mapeamento EF Core por entidade
│   └── Repositories/   # Repository Pattern
└── Services/           # Camada de aplicação
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

| Método | Rota                  | Descrição                         |
|--------|-----------------------|-----------------------------------|
| POST   | /api/auth/register    | Registar utilizador               |
| POST   | /api/auth/login       | Login — devolve token JWT         |
| GET    | /api/products         | Lista todos os produtos           |
| GET    | /api/products/{id}    | Busca produto por id              |
| POST   | /api/products         | Cria um novo produto (protegido)  |
| POST   | /api/products/seed    | Popula com dados de exemplo       |
| GET    | /api/orders/{id}      | Busca encomenda por id (protegido)|
| POST   | /api/orders           | Cria uma encomenda (protegido)    |

> Endpoints marcados como **protegido** requerem token JWT no header:
> `Authorization: Bearer {token}`

## Conceitos aplicados

- Domain-Driven Design (DDD) — Entities, Value Objects, Domain Exceptions
- Repository Pattern
- Service Layer
- DTOs de entrada e saída
- EF Core com Owned Entities (Value Objects)
- Middleware de tratamento global de erros
- Autenticação JWT com BCrypt para hash de passwords

## Roadmap

- [x] Domain Layer (Product, Money, DomainException)
- [x] Persistence (EF Core + PostgreSQL)
- [x] Service Layer
- [x] DTOs de resposta
- [x] Entidade Order
- [x] Repository Pattern
- [x] Tratamento de erros global
- [x] Autenticação JWT
- [ ] Testes unitários
- [ ] CQRS com MediatR
- [ ] Logging estruturado
- [ ] CI/CD (GitHub Actions)
