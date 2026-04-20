# Eder Management System (Backend)

Backend-only ASP.NET Core Web API project for Eder Management System.

This repository currently contains a single .NET API project with Entity Framework Core and PostgreSQL integration. The frontend is no longer part of this repository.

## Current Status

- Project is scaffolded and runnable.
- Database context and entity mappings are in place.
- OpenAPI document and Swagger UI are available in Development mode.
- No business API endpoints are mapped yet (no controller/minimal route mappings in `Program.cs`).

## Tech Stack

- .NET / ASP.NET Core: `net10.0`
- ORM: Entity Framework Core 10
- Database provider: PostgreSQL via Npgsql
- Auth-related packages: ASP.NET Core Identity EF Core package is referenced
- API docs: Microsoft OpenAPI + Swashbuckle UI
- Local infra (optional): Docker Compose for PostgreSQL + Redis

## Project Structure

```text
.
├── Program.cs
├── eder-web-api.csproj
├── eder-management-system.sln
├── appsettings.json
├── appsettings.Development.json
├── Infrastructure/
│   └── Persistence/
│       └── AppDbContext.cs
├── modules/
│   ├── auth/
│   └── account/
├── common/
├── Migrations/
├── Properties/
│   └── launchSettings.json
├── docker-compose.local.yml
└── dotnet-tools.json
```

## Prerequisites

- .NET 10 SDK
- Docker (optional, for local Postgres/Redis via Compose)
- PostgreSQL client tools (optional, helpful for DB checks)
- `dotnet-ef` CLI tool (if you plan to run migrations manually)

Install EF CLI (if not already installed):

```bash
dotnet tool install --global dotnet-ef
```

## Quick Start

Run all commands from:

```bash
cd /Users/johnhacker1998/Documents/eder/eder-management-system
```

1) Start local infrastructure (optional but recommended):

```bash
docker compose -f docker-compose.local.yml up -d
```

1) Restore and build:

```bash
dotnet restore eder-management-system.sln
dotnet build eder-management-system.sln
```

1) Apply migrations:

```bash
dotnet ef database update --context AppDbContext --project eder-web-api.csproj
```

1) Run API:

```bash
dotnet run --project eder-web-api.csproj --launch-profile http
```

API runs at `http://localhost:3000` using the `http` launch profile.

## Run Profiles and URLs

Defined in `Properties/launchSettings.json`:

- `http`
  - URL: `http://localhost:3000`
  - Browser auto-launch: disabled
- `https`
  - URLs: `https://localhost:7274` and `http://localhost:3000`
  - Browser auto-launch: enabled
  - Launch URL: `swagger`

In Development mode, OpenAPI/Swagger is wired in `Program.cs`:

- OpenAPI document: `/openapi/v1.json`
- Swagger UI (via `UseSwaggerUI`) points to `/openapi/v1.json`

## Database and Migrations

Application DB connection string is configured in `appsettings.json`:

`ConnectionStrings:DefaultConnection=Host=localhost;Port=5432;Database=eder_db;Username=postgres;Password=postgres_password`

Useful commands:

```bash
# Add a new migration
dotnet ef migrations add <MigrationName> --context AppDbContext --project eder-web-api.csproj

# Apply migrations
dotnet ef database update --context AppDbContext --project eder-web-api.csproj
```

## Configuration

### appsettings

- `appsettings.json` contains:
  - `ConnectionStrings:DefaultConnection`
  - `Logging:LogLevel`
  - `AllowedHosts`
- `appsettings.Development.json` overrides development logging behavior.

### Environment variable overrides

Example override for connection string:

```bash
export ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=eder_db;Username=postgres;Password=postgres_password"
```

## Tooling

Local .NET tools are declared in `dotnet-tools.json` (includes `csharpier`).

```bash
dotnet tool restore
dotnet csharpier .
```

## Solution Files

- Primary solution for this repository layout: `eder-management-system.sln`
- `eder.sln` references older paths (`eder-management-system\\backend\\src\\...`) that are not part of the current backend-only layout

## Known Caveats

- `docker-compose.local.yml` creates Postgres with `POSTGRES_DB=postgres`, while app config expects `eder_db`.
  - Either create `eder_db` manually, or change compose/config so both use the same DB name.
- `eder-web-api.http` currently points to `http://localhost:5170` and `GET /weatherforecast`, which does not match current launch settings and mapped endpoints.
