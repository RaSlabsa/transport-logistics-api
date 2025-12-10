# 🚚 Transport Logistics API

A robust, scalable RESTful API designed for managing transport logistics operations. Built with **.NET 8** following **Clean Architecture** principles to ensure separation of concerns, testability, and high performance.

---

## 🚀 Quick Start (Docker)

You can run the entire system (API + Database) with a single command. No need to install SQL Server or configure connection strings manually.

### Prerequisites
* [Docker Desktop](https://www.docker.com/products/docker-desktop/) installed and running.

### How to Run
1. Open your terminal in the project root folder.
2. Execute the following command:
   ```bash
   docker-compose up --build
   ```
3. Wait for the build to finish. The API will start automatically.

That's it! 🎉

👉 Open Swagger UI: http://localhost:8080/swagger

🛠 Tech Stack
Framework: .NET 8, ASP.NET Core Web API

Database: MSSQL Server (running in a Docker container)

ORM: Entity Framework Core (Code-First approach)

Architecture: N-Layer / Clean Architecture

Containerization: Docker & Docker Compose

Documentation: Swagger / OpenAPI

🏗 Architecture Overview
The solution is structured to decouple business logic from infrastructure, following Clean Architecture principles:

TransportLogistics.Core: Contains the Domain Entities and DTOs. (No dependencies).

TransportLogistics.Services: Contains Business Logic. (Depends on Core).

TransportLogistics.Repositories: Implements Database operations using EF Core. (Depends on Services & Core).

TransportLogistics.API: The entry point (Controllers) and Composition Root.

✨ Key Features
Automated Database Setup: The system automatically applies migrations and creates the database on the first Docker startup.

Scalable Structure: Ready for dependency injection and unit testing.

Containerized Environment: Ensures the application works strictly the same on any machine.
