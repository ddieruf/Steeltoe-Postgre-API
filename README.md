# Steeltoe-Postgre-API

A simple example using Steeltoe with Entity Framework Core along with the reccomended packages for microservices.

## Packages Included

- *Npgsql.EntityFrameworkCore.PostgreSQL*: provides a Postgres client for the database

- *Steeltoe.Connector.EFCore*: manages the connection with the SQL database, utilizing the Postgres client

- *Steeltoe.Management.EndpointCore*: provides the boilerplate microservice stuff like health endpoint, enhanced logging features, info endpoint, etc

- *Steeltoe.Management.TracingCore*: enhances application with automatic generation of space and trace data and also formats data to be zipkin compatible

## About EF Core Connection

The application has a dbcontext called TodoItems. Within is a model for a TodoItem. Have a look at `appsettings.json` and note the `Postgres:Client` area. That is where you specify where the database is hosted, the database name, and possible creds.

Currently this application is expecting the Postgres database to be hosted locally (ie: localhost:5432). To see more configuration options [read the docs](https://steeltoe.io/docs/3/connectors/postgresql).

## Using Project Tye

The application was developed in Visual Studio 2019 and is meant to be run through that debugger, using a local instance of Postgres. If you would like to unlock more features from the app, there is a [project tye](https://github.com/dotnet/tye) manifest provided that will spin up a database as well as a Zipkin server.

To use the app with Tye:
- In your terminal of choice `cd` to the project folder and start tye `tye run`
- Then run the application in Visual Studio like normal (F5)

## Adding in Spring Boot Admin

The project also has provisions for connecting with a [Spring Admin server](https://github.com/codecentric/spring-boot-admin) dashboard. To unlock this feature you'll need to use the above project tye hosting option.

- Uncomment the Spring Admin feature in `tye.yaml`
- Run tye as described above
- Uncomment the `RegisterWithSpringBootAdmin` statement in `Startup.cs`
- Uncomment the Spring Admin feature in `appsettings.json`
- Run the application in Visual Studio like normal (F5)
