# Catering Service

## Project Description

### Application structure

The Catering application is built according to the classic three-tier architecture and consists of the following components:

![restuml](https://user-images.githubusercontent.com/84620072/136130715-6a3eb029-8f82-4e29-bb58-39ddfe121571.png)

- DB is a relational database that stores application state in tables.
- Back-end Application is a separate .NET application that implements a web service.
- Front-end Application is a separate application that runs in the user's browser. Built with Angular. It is delivered to the user's browser through a separate endpoint, and accesses the back-end application through the REST API.

### Database

The structure of the database is shown in the figure

![restuml](https://user-images.githubusercontent.com/84620072/129891490-9916d92e-e974-4d80-bdac-dac134911ffc.png)

### Back-end Application Description

The web service is built on top of ASP. NET WebAPI and provides an external API built in REST architectural style. The database is accessed through the EntityFramework Core.

Our project consists of:

- api - built using .Net Core, Generic Repository Pattern, Unit Of Work, Swagger and MSSQL.
  - Catering.API - Consists of Constrollers, Helpers, Extensions, DTOs, Configuration.
  - Catering.BLL - Consists of Business Logic Part: Services.
  - Catering.Common - Consists of Web Client.
  - Catering.DAL - Consists of Data Access Logic: entities, dbContexts, repositories.
- client - built using Angular 9, Bootstrap 4, ngx-bootsrap, Font Awesome.
