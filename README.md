# SimpleCleanArchitecture.Net

SimpleCleanArchitecture.Net is an elegantly designed WebApi project, developed with the latest .NET technologies.
This project has been constructed on the .NET 8.0 framework and leverages the Entity Framework for object-relational mapping, applying the Code First approach.
We have adopted the principles of Clean Architecture to ensure a maintainable and decoupled architecture.
For object mapping, the Mapster library has been employed to facilitate the efficient translation between different object models.

## Framework and Tools
- Framework: .NET 8.0
- Object Mapper: Mapster
- ORM: Entity Framework (CodeFirst approach)
- Architecture: Clean Architecture
  
## Database Setup
To initialize and update your database, please execute the following commands within the Package Manager Console. Ensure that the MyInsurance.Infrastructure project is set as the default project in the console.

To create an initial migration, run:

```Add-Migration InitM -Project MyInsurance.Infrastructure```

To apply the migration and update your database, run:

```Update-Database -Project MyInsurance.Infrastructure```

Your contributions and insights are highly valued. Kindly take a moment to explore the project, and I welcome you to provide your feedback or suggestions.
