# Recipe

This project is a .NET Core application that implements a CQRS (Command Query Responsibility Segregation) architecture with MediatR for handling requests and Elasticsearch for efficient searching and indexing. The project is organized into several layers to promote a clean separation of concerns and maintainability.

## Project Structure

The project is organized into the following layers:

- **Application**: This layer contains the core business logic and application-specific rules. It includes CQRS handlers (commands and queries), DTOs, and validation logic.

- **Domain**: This layer defines the core entities, value objects, and domain services. It is independent of any specific technology or framework and represents the business model of the application.

- **Persistence**: This layer is responsible for data access. It includes the implementations of repositories, the Entity Framework Core context, and database migrations.

- **Infrastructure**: This layer provides implementations for external services, such as Elasticsearch, email services, file storage, etc. It also contains the dependency injection configurations for the application.

## Technologies Used

- **.NET Core**: The framework used to build the application.
- **MediatR**: A mediator library that decouples the sending of requests from their handling.
- **Elasticsearch**: A distributed search and analytics engine used for storing and searching large volumes of data efficiently.
- **Entity Framework Core**: An ORM (Object-Relational Mapper) used for data access.
- **AutoMapper**: A library used for mapping objects between different types.
- 
