# Clean Architecture

<p align="center">
  <img src="https://www.macoratti.net/20/10/aspc_cleanarq11.jpg" alt="Onion Architecture"/>
</p>

## About <a name = "about"></a>

In this project we will approach the concept of Clean Architecture and create an ASP .NET Core solution using this concept proposed by Uncle Bob in his book Clean Architecture.
The concept of Clean Architecture is based on the Dependency Rule, which states that the source code dependency can only point to the inside of the application.

The layers of Clean Architecture

According to the ASP.Net Core documentation, our source code can be structured as separate projects or layers with dependency flow from outside to the application's core layer.

The dependency flow can be represented as shown in the figure:
<p align="center">
  <img src="https://www.macoratti.net/20/10/aspc_cleanarq12.jpg" alt="Clean Architecture layers"/>
</p>

From which we can deduce the following:

- Application Core types include interfaces, services, DTO (data transfer objects), and entities (business models);
 
- Infrastructure types include EF Core types (DbContext, Migration), data access implementation types (Repositories), Infrastructure specific services (eg FileLogger or SmtpNotifier);
 
- UI types include controllers, filters, views, view models, initialization;
 
- Test types include unit tests, integration tests;

Note that the solid arrows represent compile-time dependencies, while the dashed arrow represents a run-time-only dependency.

With clean architecture, the UI layer works with interfaces defined in Application Core at compile time and ideally shouldn't know about implementation types defined in the infrastructure layer.

At runtime, however, these implementation types are required for the application to run, so they need to be present and connected to Application Core interfaces via dependency injection.

The following figure shows a closer look at the architecture of an ASP.NET Core application when built following these recommendations:

<p align="center">
  <img src="https://www.macoratti.net/20/10/aspc_cleanarq18.png" alt="ASP.NET Core Architecture"/>
</p>

## Application Layer <a name = "application_layer"></a>

The Application Core or Application Core (use cases and entities) contains the high-level business rules of the software that are generally stable and do not change often. Typically, these are the application's functional requirements.

Use cases can be interfaces or services, while entities are usually business model classes that are persistent.