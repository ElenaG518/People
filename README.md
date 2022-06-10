# People

.NET 6 application using MAC version of Visual Studio.  It includes a mockdb with API endpoints, controller for API and another controller for views.

CRUD functionality for all controllers
Implements repo interface to decouple controllers from business logic and facilitate testing.

Using Entity Framework.

.NET documetation:
https://docs.microsoft.com/en-us/dotnet/




Migrations:

https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli

dotnet ef migrations add InitialCreate
dotnet ef database update

