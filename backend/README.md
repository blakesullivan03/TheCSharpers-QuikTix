
# QuikTix Backend Setup with MS EF Core SQLite

## Import MS EF Core SQLite
To use SQLite with Entity Framework Core, run the following command:
```bash
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
This installs the SQLite provider for EF Core, enabling your project to interact with SQLite databases.

## Remove Existing Migrations
If your project contains existing migrations that need to be removed, use:
```bash
dotnet ef migrations remove
```
This command removes the last migration, useful when making changes to your data model.

## Build the Project
Ensure your project compiles correctly before creating migrations:
```bash
dotnet build
```
Building ensures there are no syntax or compilation errors that would interfere with creating migrations.

## Add Initial Migration
Generate an initial migration to create the database schema based on your models:
```bash
dotnet ef migrations add InitialMigration
```
This creates a new migration file containing instructions to create tables and relationships defined in your data models.

## Create SQLite Database
After defining migrations, create and inspect your SQLite database with the following commands:
```bash
sqlite3 QuikTixDb.db
.tables
```
The first command opens the SQLite CLI with your database file. The `.tables` command lists all the tables in your database.

## Temporary Data in the Database
The application includes a `MovieSeeder.cs` file that seeds the database with temporary data for testing. This data is not persistent and may be overwritten if migrations are updated or the database is reseeded.

## Run the Application
To start the application, use:
```bash
dotnet run
```
Running this command launches your application, making the API endpoints available.

## View Endpoints with Swagger
Swagger UI provides a visual interface to test API endpoints. Once the application is running, navigate to:
```
https://localhost:7267/swagger/index.html
```

## Additional Endpoints (Not Listed in Swagger)
The following endpoints are for sorting movies and can be accessed directly:

- **Sort by A to Z**:  
  [https://localhost:7267/api/movies/get?sortBy=AtoZ](https://localhost:7267/api/movies/get?sortBy=AtoZ)
- **Sort by Z to A**:  
  [https://localhost:7267/api/movies/get?sortBy=ZtoA](https://localhost:7267/api/movies/get?sortBy=ZtoA)
- **Sort by Release Date Ascending**:  
  [https://localhost:7267/api/movies/get?sortBy=ReleaseDateAsc](https://localhost:7267/api/movies/get?sortBy=ReleaseDateAsc)
- **Sort by Release Date Descending**:  
  [https://localhost:7267/api/movies/get?sortBy=ReleaseDateDesc](https://localhost:7267/api/movies/get?sortBy=ReleaseDateDesc)
- **Sort by Duration Ascending**:  
  [https://localhost:7267/api/movies/get?sortBy=DurationAsc](https://localhost:7267/api/movies/get?sortBy=DurationAsc)
- **Sort by Duration Descending**:  
  [https://localhost:7267/api/movies/get?sortBy=DurationDesc](https://localhost:7267/api/movies/get?sortBy=DurationDesc)
- **Sort by Best Rated**:  
  [https://localhost:7267/api/movies/get?sortBy=BestRated](https://localhost:7267/api/movies/get?sortBy=BestRated)
- **Sort by Popularity**:  
  [https://localhost:7267/api/movies/get?sortBy=Popular](https://localhost:7267/api/movies/get?sortBy=Popular)
