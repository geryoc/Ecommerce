# Ecommerce

Simple Ecommerce App as a proof of concept to exercise my skills on ASP.NET Core.

There is a client app using Angular.

## Design Principles Used:

- Services based folder structure:

Basically this is dividing the Web API application in components or "microservices" inside a monolithic application.
Based on this approach: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice
Instead of deploying each service individually, dividning the application in deployment units, we divide the application in logical units or logic microservices, and deploy a single unit.

The basic structure for the application is something like this:
  * WebAPI
    * Services
      * __Category__
        * Entities
            Category.cs
        * Models
            Requests
            Responses
        * CategoryController.cs
      * __Product__
        * Helper
        * Entities
          Product.cs
        * Models
            Requests
            Responses
        * ProductController.cs
  
    * Shared
      * Database
      * Coniguration
      * ...

- Entities: Domain objects

    Each domain object represents an information unit or information asset that is managed by an application service.
    I prefer to define them this way, rather than an business entity form the reality.
    Because at the end of the day entities are just a piece of information stored somewhere.
    Generally it represnts a table on the database, but it could also be a response from an external servcie, etc.
    The collection of domain objects represent the Data Model of the hole application.

- Models:

    They represent a Request or a Response in an endpoint of the Web API. They define the contract between the Web API and the client applications.
    Every Action on a Controller should define its unique Request Model. Reusing request models on more than one Action is a very bad practice.
    The only thing that should be reused is an entity resource model (The response object of an endpoint).

## Technologies and libraries used:

- .NET 5 asp.net core
- Using Mapster for mapping contract and resource objects to domain objects
- Entity Framework Core
- Using System.ComponentModel data annotations and validators for request inpput validation.
