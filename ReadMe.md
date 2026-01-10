# Warming Up .Net Core

This project can be used as a reference for building API's using .Net Core.




## It Contains
- Entity Framework *(ORM)*
- Swagger *(API requests tests generated automatically)*
- MVC Achitecture *(So far)*

## Commom terminal commands

__Run the application and show logs in real time__
````
dotnet run watch

````

__Install dontnet-ef CLI globally__
````
dotnet tool install --global dotnet-ef
````

__Create migrations__
````
dotnet ef migrations add <YOUR MIGRATION>
````

__Execute migration__
````
dotnet ef database update
````