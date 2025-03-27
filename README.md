# .NET Boilerplate Web API Documentation

## Introduction

The **.NET Boilerplate Web API** is a project under development designed to serve as a starting point for building Web APIs using .NET or .NET Core, adhering to the principles of **Clean Architecture**. This boilerplate provides a structured foundation that incorporates modern architectural patterns and design principles, making it easier for developers to create robust, scalable, and maintainable applications. The key principles and patterns integrated into this boilerplate include:

- **Hexagonal Architecture** (Ports and Adapters)
- **Domain-Driven Design (DDD)**
- **Command Query Responsibility Segregation (CQRS)**
- **Event Sourcing (ES)**
- **SOLID Principles**

This documentation outlines the structure, components, and usage of the boilerplate, providing a comprehensive guide for developers looking to leverage its capabilities.

---

## Project Overview

The .NET Boilerplate Web API is organized into distinct layers following Clean Architecture, ensuring a clear separation of concerns. The primary goal is to decouple business logic from infrastructure and presentation concerns, enhancing testability and maintainability. The layers are:

1. **Domain Layer**: Contains the core business logic and domain models.
2. **Application Layer**: Defines use cases and orchestrates application behavior.
3. **Infrastructure Layer**: Implements external concerns like data persistence and services.
4. **Presentation Layer**: Exposes the API endpoints to the outside world.

These layers interact in a unidirectional flow, with dependencies pointing inward toward the domain layer, adhering to the Dependency Inversion Principle.

---

## Architectural Principles

### Clean Architecture

**Clean Architecture** is the foundational philosophy of this boilerplate. It organizes the application into concentric layers, with the innermost layer (Domain) being independent of external systems. The key benefits include:

- **Independence**: Business logic is isolated from frameworks, databases, and UI.
- **Testability**: Layers can be tested in isolation.
- **Maintainability**: Changes in one layer (e.g., database) don’t affect others.

### Hexagonal Architecture (Ports and Adapters)

**Hexagonal Architecture** enhances Clean Architecture by defining the application’s core logic as a hexagon surrounded by **ports** (interfaces) and **adapters** (implementations). This pattern ensures that the business logic remains agnostic to external systems, such as databases or APIs. For example:

- A port might define a repository interface.
- An adapter might implement that interface using Entity Framework Core.

### Domain-Driven Design (DDD)

**DDD** focuses on modeling the business domain within the software. The domain layer includes:

- **Entities**: Objects with identity (e.g., a `Customer` with an ID).
- **Value Objects**: Objects defined by attributes (e.g., an `Address`).
- **Aggregates**: Groups of related entities treated as a single unit.
- **Repositories**: Interfaces for data access (implemented in the infrastructure layer).

This approach ensures that the code reflects the real-world domain it represents.

### CQRS (Command Query Responsibility Segregation)

**CQRS** separates operations that modify data (**commands**) from those that retrieve data (**queries**). This can improve performance and scalability by allowing separate optimization of read and write paths. For example:

- A command might be `CreateCustomer`.
- A query might be `GetCustomerById`.

### Event Sourcing (ES)

**Event Sourcing** stores the state of the application as a sequence of events rather than a single snapshot. Each event (e.g., `CustomerCreated`, `OrderPlaced`) is persisted, and the current state is derived by replaying these events. Benefits include:

- Full audit trail of changes.
- Ability to rebuild state or debug issues.

### SOLID Principles

The boilerplate adheres to the **SOLID** principles to ensure clean and maintainable code:

- **S**: Single Responsibility Principle – Each class has one reason to change.
- **O**: Open/Closed Principle – Classes are open for extension, closed for modification.
- **L**: Liskov Substitution Principle – Subtypes can replace their base types without altering behavior.
- **I**: Interface Segregation Principle – Clients depend only on interfaces they use.
- **D**: Dependency Inversion Principle – High-level modules depend on abstractions, not implementations.

---

## Project Structure

The project is divided into the following layers, each with specific responsibilities:

### Domain Layer

- **Purpose**: Encapsulates the business logic and domain models.
- **Components**:
  - **Entities**: Core objects like `Customer` or `Order`.
  - **Value Objects**: Immutable objects like `Money` or `Email`.
  - **Aggregates**: Roots like `Order` that enforce consistency boundaries.
  - **Domain Services**: Logic that spans multiple entities.
  - **Repository Interfaces**: Define data access contracts (e.g., `ICustomerRepository`).
- **Key Feature**: Completely independent of external frameworks or technologies.

### Application Layer

- **Purpose**: Coordinates application behavior and defines use cases.
- **Components**:
  - **Application Services**: Execute business use cases (e.g., `OrderService`).
  - **Commands**: Operations like `CreateOrderCommand`.
  - **Queries**: Operations like `GetOrderDetailsQuery`.
  - **Interfaces**: Contracts for infrastructure dependencies.
- **Key Feature**: Implements CQRS by separating commands and queries.

### Infrastructure Layer

- **Purpose**: Handles external systems and technical details.
- **Components**:
  - **Repositories**: Implementations like `CustomerRepository` using a database.
  - **Event Store**: Stores events if Event Sourcing is used (e.g., using a library like EventStoreDB).
  - **External Services**: Adapters for APIs or message queues.
- **Key Feature**: Provides concrete implementations of application-layer interfaces.

### Presentation Layer

- **Purpose**: Exposes the application via a Web API.
- **Components**:
  - **Controllers**: Handle HTTP requests (e.g., `CustomersController`).
  - **DTOs**: Data Transfer Objects for request/response payloads.
- **Key Feature**: Thin layer that delegates to the application layer.

---

## Configuration and Setup

To get started with the .NET Boilerplate Web API:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/MarcosFerreira17/clean-architecture-boilerplate.git
   ```

2. **Restore Dependencies**:
   ```bash
   cd clean-architecture-boilerplate
   dotnet restore
   ```

3. **Configure Environment**:
   - Edit `appsettings.json` or set environment variables for:
     - Database connection strings.
     - External service credentials (e.g., API keys).
   - Example:
     ```json
     {
       "ConnectionStrings": {
         "Default": "Server=localhost;Database=BoilerplateDb;Trusted_Connection=True;"
       }
     }
     ```

4. **Run the Application**:
   ```bash
   dotnet run --project src/Presentation
   ```
   - The API will be available at `http://localhost:5000` (default).

---

## API Usage

The Web API follows RESTful conventions. Example endpoints:

- **Create a Customer**:
  ```
  POST /api/customers
  {
    "name": "John Doe",
    "email": "john.doe@example.com"
  }
  ```

- **Get a Customer**:
  ```
  GET /api/customers/{id}
  ```

Responses are returned in JSON format, with appropriate HTTP status codes (e.g., `201 Created`, `200 OK`).

---

## Testing

The boilerplate includes a testing framework:

- **Unit Tests**: Test domain logic and application services.
  - Location: `tests/Domain.Tests`, `tests/Application.Tests`.
- **Integration Tests**: Test interactions with infrastructure (e.g., database).
  - Location: `tests/Infrastructure.Tests`.
- **End-to-End Tests**: Test the full API workflow.
  - Location: `tests/EndToEnd.Tests`.

Run tests with:
```bash
dotnet test
```

---

## Deployment

To deploy the application:

1. **Build**:
   ```bash
   dotnet build --configuration Release
   ```

2. **Publish**:
   ```bash
   dotnet publish --configuration Release --output ./publish
   ```

3. **Deploy**:
   - Copy the `publish` folder to your server.
   - Configure the hosting environment (e.g., IIS, Kestrel, Docker).
   - Example Docker deployment:
     ```dockerfile
     FROM mcr.microsoft.com/dotnet/aspnet:6.0
     COPY ./publish /app
     WORKDIR /app
     ENTRYPOINT ["dotnet", "Presentation.dll"]
     ```

4. **Set Environment Variables**:
   - Ensure database connections and other settings are configured on the server.

---

## Contributing

Contributions are encouraged! Follow these steps:

1. Fork the repository.
2. Create a feature branch: `git checkout -b feature/my-feature`.
3. Commit changes: `git commit -m "Add my feature"`.
4. Push to your fork: `git push origin feature/my-feature`.
5. Submit a pull request.

Please include tests and follow the existing code style.