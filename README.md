# Ecommerce

Simple demo ecommerce app for trying out .NET 5 Web API.

## Design Principles Used:

- Components/Services based Arquitecture:

Basically this is dividing the Web API application in components or "microservices" inside a monolithic application.

Based on this approach: https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/ddd-oriented-microservice

Instead of deploying each service individually, dividning the application in deployment units, we divide the application in logical units or logic microservices, and deploy a single unit.

So the basic structure for the application is something like this:
  * WebAPI
    * Services
      * __Category__
        * Application
          * Create
          * Search
          * Delete
          * ...
        * Domain
          Category.cs
        * Web
          * CategoryController.cs
          * CategoryResource.cs
      * __Product__
        * Application
          * Create
          * Search
          * Delete
          * ...
        * Domain
          Product.cs
        * Web
          * ProductController.cs
          * ProductResource.cs
  
    * Shared
      * Database
      * Coniguration
      * ...

- Domain objects

  Each domain object represents an information unit or information asset that is managed by an application service.
  I prefer to define them this way, rather than an business entity form the reality.
  Because at the end of the day entities are just a piece of information stored somewhere.
  Generally it represnts a table on the database, but it could also be a response from an external servcie, etc.
  The collection of domain objects represent the Data Model of the hole application.

- CQRS for handling Applicaion Operations:

Insted of using the popular Service Pattern from DDD y prefer using the CQRS pattern for application operations. 
With this approach each operation that can be perform over a particular domain object is specified with 3 classes: Request, Handler and Response.
Each operation is isolated and is not part of a big domain service. So it can be used indiviually and other elements dont need to import or depend upon the hole service.
Other components can just use the particular operation they need.

So for example an application operaion could be creating a new category for products:
  - CreateCategoryRequest.cs : This DTO has the required data for creating the categor (Category Name for example)
  - CreateCategoryHandler.cs: This class has an exceute method with the logic for performing the operation.
  - CreateCategoryResponse.cs: This DTO has the data for the result of the operation. In this case holds the created Cateogry domain object.

More on CQRS:

https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/microservice-application-layer-implementation-web-api
https://martinfowler.com/bliki/CQRS.html


## Technologies and libraries used:

- .NET 5 asp.net core
- Angular for the Client App.
- Using Mapster for mapping contract and resource objects to domain objects 
- Mediatr for implementing Mediator Pattern and CQRS
- Entity Framework Core
- Using System.ComponentModel data annotations and validators for request inpput validation and application business logic validation.
