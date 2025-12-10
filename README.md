# 🚚 Transport Logistics API

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
![MSSQL](https://img.shields.io/badge/MSSQL-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)

A robust, scalable RESTful API designed for managing transport logistics operations. Built with **Clean Architecture** principles to ensure separation of concerns, testability, and high performance.

---

## 🚀 Quick Start (One Command)

Run the entire system (API + Database) instantly using Docker.

### Prerequisites
* [Docker Desktop](https://www.docker.com/products/docker-desktop/) installed.

### How to Run
1. Open your terminal in the project root.
2. Execute:
   ```bash
   docker-compose up --build
   ```
3. Wait for the build to finish. The database will be created automatically.

Use swagger UI	http://localhost:8080/swagger	API Documentation & Testing

---

## 🛠 Tech Stack

| Category | Technology |
| :--- | :--- |
| **Framework** | .NET 8, ASP.NET Core Web API |
| **Database** | MSSQL Server (Containerized) |
| **ORM** | Entity Framework Core (Code-First) |
| **Architecture** | N-Layer / Clean Architecture |
| **DevOps** | Docker, Docker Compose |
| **Docs** | Swagger / OpenAPI |

---

## 🏗 Architecture & Project Structure

The solution follows **Clean Architecture** rules to decouple business logic from infrastructure.

```text
TransportLogistics
├── 📂 TransportLogistics.Core           # Domain Layer (Entities, Enums)
│   ├── No dependencies (Pure C#)
│
├── 📂 TransportLogistics.Services       # Application Layer (Business Logic)
│   ├── Depends on: Core
│   ├── Contains: DTOs, Interfaces, Service Implementations
│
├── 📂 TransportLogistics.Repositories   # Infrastructure Layer (Data Access)
│   ├── Depends on: Core
│   ├── Contains: EF Core DbContext, Migrations, Repository Implementations
│
└── 📂 transport-logistics-api           # API Layer (Entry Point)
    ├── Depends on: Services, Repositories
    ├── Contains: Controllers, DI Configuration, Dockerfile
```

## ✨ Key Features

* ✅ **Automated Database Setup:** The system automatically applies migrations on startup. No manual SQL scripts needed.
* ✅ **Containerized Environment:** Guaranteed to work on any machine (Windows/Linux/Mac) via Docker.
* ✅ **Scalable Architecture:** Repository Pattern and Dependency Injection make the code testable and modular.
* ✅ **Data Integrity:** Strict validation rules and foreign key constraints managed by EF Core.
