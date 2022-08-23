
# CRUD Operations using ASP.NET Core MVC

In this application there are CRUD Operations that are performed in a PostgreSQL Data Base.

I was studying how to use EntityFramework with PostgreSQL and how to do CRUD Operations.




## Used packages

**Microsoft.EntityFrameworkCore** - Version: 6.0.8

**Microsoft.EntityFrameworkCore.Tools** - Version: 6.0.8

**Npgsql.EntityFrameworkCore.PostgreSQL** Version: 6.0.6
## Configure your database

If you are using a PostgreSQL database, you need to go to appsettings.json file and edit the fields with your context.

```json
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=5432;user id=postgres;password=123456;database=Produtos"
  },

```


## Synchronize the database

Open a console inside the folder of your project and run
```
dotnet ef migrations add firstMigration
```

Than, to create the database to be used in the application
```
dotnet ef database update
```