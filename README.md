# Clean Architecture Playground

## App Summary

This repository demonstrates the implementation of Clean Architecture principles using a .NET Minimal API.

It separates concerns across different layers and projects to ensure maintainability, scalability, and testability.
The app architecture divides the code into layers to enforce clear boundaries between different concerns like business logic, data access, and user interfaces.

The brief for this simple project is to retrieve data about Breweries. We will use the [Open Brewery API](https://www.openbrewerydb.org/documentation).

## Project Structure

The solution is divided into several projects, each playing a specific role within the Clean Architecture design:

### 1. **Application**
- **Purpose**: This project holds the business logic and core use cases of the application. It contains all the commands, queries, and DTOs (Data Transfer Objects) that represent the core functionality of the system.
- **Contents**:
    - Commands and Queries: Handled via the [Mediatr library](https://github.com/jbogard/MediatR).
    - Interfaces for use cases: Define the actions that other layers must implement.

### 2. **Domain**
- **Purpose**: Contains the core entities and business rules of the system. It defines the business model, with domain-specific logic and rules, and is completely independent of external libraries or frameworks.
- **Contents**:
    - Domain entities.

### 3. **Infrastructure**
- **Purpose**: Provides concrete implementations of interfaces from the Application project, primarily dealing with third-party services.
- **Contents**:
    - API clients for communication with external services.

### 4. **Endpoints (API)**
- **Purpose**: This project is responsible for presenting the application to the outside world via HTTP APIs. It acts as the entry point to the system.
- **Contents**:
    - .NET Minimal API endpoints for handling incoming requests.
    - Dependency injection configuration, including the registration of Mediatr handlers.

### 5. **Persistence**
- **Purpose**: Provides concrete implementations of interfaces from the Application project, primarily dealing with external concerns like data persistence.
- **Contents**:
    - Entity Framework Core repository implementations for accessing the database.
    - Migrations
    - Repositories

## The Flow of Code
 
![image](https://github.com/user-attachments/assets/f78fcd43-25b0-47ca-89dd-89c7ea3617a6)

## Package Summary

Below is a list of key packages used in the solution, along with the projects they are included in:

### 1. **MediatR**
- **Included In**: Application, Endpoints
- **Purpose**: Implements the CQRS (Command Query Responsibility Segregation) pattern, allowing for separation of concerns by decoupling requests from handlers. It facilitates the dispatching of commands and queries across the system.

### 2. **Entity Framework Core**
- **Included In**: Persistence
- **Purpose**: Provides ORM (Object-Relational Mapping) for working with databases. It is used to map domain models to the underlying relational database and to manage data persistence.

### 3. **Swashbuckle (Swagger)**
- **Included In**: Endpoints
- **Purpose**: Generates Swagger documentation for the API, enabling developers to easily explore the available endpoints and test the API directly from a browser.

### 4. **Microsoft.Extensions.DependencyInjection**
- **Included In**: Endpoints
- **Purpose**: Provides dependency injection services, allowing for better separation of concerns and making the application more testable and maintainable.

## How to Run the Application

1. Clone the repository:
    ```bash
    git clone https://github.com/nouriach/clean-architecture-playground.git
2. Navigate to the solution folder:
    ```bash
    cd clean-architecture-playground

3. Build the solution:
    ```bash
    dotnet build

4. Run the migrations:
    ```bash
   dotnet ef database update --project Endpoints/Endpoints.csproj

5. Run the API project:
    ```bash
    dotnet run --project src/Endpoints

6. Navigate to http://localhost:5000/swagger to access the Swagger UI for API documentation.

## Want to get involved?

The following `Commands` have been left unfinished:
 ```
|_Features
    |_Commands
        |_CreateBrewery
            |_CreateBrewery
            |_CreateBreweryHandler
        |_DeleteBrewery  
            |_DeleteBrewery
            |_DeleteBreweryHandler
        |_UpdateBrewery
            |_UpdateBrewery
            |_UpdateBreweryHandler
```
Use these requirements to practice writing full vertical slices that work through the Clean Architecture structure.
The task will also benefit people who have never used Mediatr before.

Build out your endpoint, trigger your Mediatr handler and call the `BreweryRepository` to retrieve and modify data in the database.