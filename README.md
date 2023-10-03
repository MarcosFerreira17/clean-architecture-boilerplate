# .NET Boilerplate

###### In development...

<p align="center">
  <img src="images/clean_architecture.png" alt="dotnet-Boilerplate-clean_architecture logo" width="700"/>
</p>

A .NET/.NET Core Boilerplate to use Clean Architecture and DDD (Domain Driven Design).

### Documentation

You can find information about this Boilerplate in:

- [Main Architecture](docs/ARCHITECTURE.md)
- [Hexagonal Architecture](docs/HEXAGONAL.md)
- [DDD](docs/DDD.md)
- [CQRS AND ES](docs/CQRS-ES.md)
- [SOLID](docs/SOLID.md)

### Prerequisites

#### [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)

#### [Docker]()

This is just the version used by the Boilerplate, if you need to use a newer or older one, you can do it manually after.

### Usage

1. Clone this repository
2. To allow the api to be created you will need to install the Boilerplate from nuget:

```
dotnet new -i {{Path_where_you_cloned_the_repository}}
```

- Example:

```
dotnet new -i "C:\your-paste\dotnet-Boilerplate\Boilerplate"
```

3. To check that the Boilerplate has been installed successfully:

```
dotnet new -l
```

- There should now be a new Boilerplate **dotnet_Boilerplate_onion**

```
Boilerplates                                          Short Name                 Language          Tags
----------------------------------------------------------------------------------------------------------
.NET Core 6.0 Boilerplate with CQRS and DDD       webapi-tiers      [C#]              Web/API/Microservices
```

4. Create the .Net Core Solution

```
dotnet new dotnet_Boilerplate -n {{Namespace_of_your_project}} -o <outputFolder>
```

- This will create the folder containing a solution and project folder.
  ![](images/installation.jpg)

And you are ready to go, you can use Visual Studio, Visual Studio Code or any other IDE to proceed with your coding.

### Structure of the Boilerplate

```
C:.
│
├───Core
│   │
│   ├───Boilerplate.Application
│   │   │
│   │   └Boilerplate.Application.csproj
│   │
│   │
│   └───Boilerplate.Domain
│       │
│       └Boilerplate.Domain.csproj
│
│
│
├───External
│   │
│   ├───Boilerplate.API
│   │
│   └───Boilerplate.Infrastructure
│       │   DependencyInjection.cs
│       │   Boilerplate.Infrastructure.csproj
│       │
│       ├───DataContext
│       │       ApplicationDbContext.cs
│       │
│       ├───Migrations
│       │
│       ├───Common
│       │       BaseRepository.cs
│       │
│       └───Repositories
│               BoilerplateRepository.cs
│
└───Tests
    └───Architecture.Tests
        │   └───Architecture.Tests.csproj
        │
        └───Unit.Tests
              └───Unit.Tests.csproj
```
