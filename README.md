# GocHub
Exploration of Blazor + ASP.NET Core API + MS SQL Server 2019 Temporal databases


## How to run

### Required
- SQL Server 2017 / 2019
- SQL Server Management Studio (SSMS) 17/18
- Visual Studio 2017 __with__ the _Blazor Language services_ extension

### Steps
- open SSMS and import the database ( [Database script](https://github.com/goranalkovic/GocHub/blob/dev/Database/GenerateDb.sql) )
- import the project from GitHub
- in the [`tbp.Server/tbpdbContext.cs`](https://github.com/goranalkovic/GocHub/blob/dev/tbp.Server/tbpdbContext.cs), check the connection string and change accordingly
- run the app (the default project should be `tbp.Server`)
