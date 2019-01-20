# GocHub
Exploration of Blazor + ASP.NET Core API + MS SQL Server 2019 Temporal databases


## How to run

### Required
- SQL Server 2017 / 2019
- SQL Server Management Studio (SSMS) 17/18
- Visual Studio 2017 __with__ the _Blazor Language services_ extension

### Steps
- open SSMS and import the database (will be uploaded soon)
- import the project from GitHub
- in the `tbp.Server/tbpdbContext.cs`, change the connection string in `optionsBuilder.UseSqlServer( (...) );` to match your local instance
- run the app!
