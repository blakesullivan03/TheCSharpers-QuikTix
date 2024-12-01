# QuikTix Project

QuikTix is a web application designed for managing movie ticket bookings, providing functionalities such as viewing movies, booking tickets, and viewing reviews. This project uses ASP.NET Core with Entity Framework Core for the backend and SQL Server LocalDB for the database.

## Getting Started

Follow these steps to set up the project and run it locally on your machine.

### Prerequisites

1. **Install .NET SDK**: Make sure you have the [latest version of .NET SDK](https://dotnet.microsoft.com/download) installed.
2. **Install SQL Server LocalDB**: Follow the official [Microsoft LocalDB Installation Guide](https://learn.microsoft.com/sql).

### Setup

1. **Clone the Repository**:
   Clone this repository to your local machine.
   git clone https://github.com/your-username/QuikTix.git
   cd QuikTix
2. **Install Dependecies**
   dotnet restore
3. **Create an Instance of the Local Database using LocalDB**
   Verify LocalDB is installed
   sqllocaldb i
   This will show a list of LocalDB instances. If you see (localdb)\MSSQLLocalDB in the list, LocalDB is installed.

   Create the Database
   dotnet ef database update
   This will use Entity Framework Core to create a LocalDB instance named QuikTixDb and apply all necessary migrations

   Set your Connection String
   Ensure the connection string in appsettings.Development.json looks like this:
     "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=QuikTixDb;Trusted_Connection=True;"
     }
4. **Run the Application**
   dotnet run
   Once the application is running, you can access the API via Swagger UI at http://localhost:5056/swagger to test the API endpoints.
   
