Summary - WEB API for Ecommerce Store selling Shoes.
Technologies Used - ASP.NET WEB API .NET 5, EF Core,EF migrations code first approach,
Repository/Generic Repository Pattern, Services dependent on Repositories, SQlite database , DI using inbuilt configure.services
container and exclusive DI of services and repo's  using Unity. Service Factory using Unity and provding the instances of different services.


Steps in Detail
1. Used donet cli to create a ShoeStore solution
cmd -> dotnet new sln

2. Created classlib Shoes.API  Controllers. REST 
cmd-> dotnet new webapi Shoes.API 

4. Created classlib Shoes.Application   
cmd-> dotnet new classlib Shoes.Application

3. Create a classlib Shoes.Domain for Domain classes and Behavior  
cmd-> dotnet new classlib Shoes.Domain

5  Create a classlib Shoes.Persistence for Repository CRUD operations and EF DataContext ORM. 
cmd->  dotnet new classlib Shoes.Persistence

6. Added Project References
cmd -> dotnet sln add Shoes.API
dotnet sln add Shoes.Application
dotnet sln add Shoes.Domain  
dotnet sln add Shoes.Persistence  

7. Created and grouped data model class and abstract behavior inside Shoes.Domain Project. Aggregated inside different modules.

8. Abstrated away  concrete implementation of Repositories inheriting from GenericRepository<T> for common  functionality inside the Shoes.Persistence project layer 

9  Defined Services inside Shoes.Application. Service layer abstraction between webapi controllers and repositories 
   Individual Services for each repository and corresponding repository injected via Constructor Dependency Injection Pattern

10. Service factory class instantating a Unity Container and registered the services and repositories in the container

11. Service factory GetServiceInstance method to resolve the Type

12. Service factory added as a service Startup.cs configure services method and passing the data context object

13 Use of SQLITE database

14 Added EF Core tool for Database Migrations for DBSets entities mentioned in DataContext
cmd -> dotnet ef migrations add InitialCreate -p Shoes.Persistence -s Shoes.API

15 Database creation inside terminal window
cmd-> dotnet ef database update
16 DB drop
cmd->  dotnet ef database drop

17 Seeder class to see the E-commerce database tables . Its called from Program.cs as below before host is run.

                var context = services.GetRequiredService<DataContext>();
                await context.Database.MigrateAsync();  /// For Migration scripts.
                var seeder = services.GetRequiredService<Seeder>();  // Seeder class to seed the data.
                await seeder.SeedData();    // seed data
                await context.SaveChangesAsync(); 

18 Added Nuget package Dependencies 
                      Microsoft.EntityFrameworkCore.dll
                      Microsoft.EntityFrameworkCore.Proxies
                      Microsoft.EntityFrameworkCore.Design
                      Microsoft.EntityFrameworkCore.SQlite.dll


19. Created controller searchapi with attribute based routing [Route] attribute on contollers

20 Action methods for to retrieve product filters like Brand, Color, Categories, Person(Men, Women and Kids) and Size

21. productApi work in Progress. GetAllProducts
FilterProducts();

22  CTRL + SHIFT + ` to launch terminal.
cmd->  dotnet build 
cmd -> dotnet run

23. Test the API's using Postman.

GET
http://localhost:5000/searchApi/brands  // Get All Shoe brands
http://localhost:5000/searchApi/categories  // Get All Shoe categories
http://localhost:5000/searchApi/sizes   // gET
http://localhost:5000/searchApi/person
http://localhost:5000/searchApi/colors
http://localhost:5000/productApi/products   // Get All products



GET
http://localhost:5000/productApi/filterProducts   // Get Products with filter parameters.

