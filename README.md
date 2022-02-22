# Task tracker project

### Description
This project allows users to store projects and tasks. For persistence it utilizes PostgreSQL db, for interface it utilizes REST-based Web API.

The project is built according to the Clean Architecture principles.

### System requirements
* .NET 6
* PostgreSQL (v14 was used)

### Usage
1. Insert your connection string for the Postgres server in the appsettings.json (within the TaskTracker.WebAPI project);
2. Cd to solution folder and apply migrations:
    dotnet ef database update --project TaskTracker.Infrastructure --startup-project TaskTracker.WebAPI
3. Start the app:
    dotnet run --project TaskTracker.WebAPI
