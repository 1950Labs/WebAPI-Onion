---
title: Config Persistence
---
<SwmSnippet path="/Persistence/ServiceExtensions.cs" line="17">

---

1. **DbContext Setup with SQL Server**:

   - `services.AddDbContext<AdventureWorkDbContext>(options => ...)`: This line adds the `AdventureWorkDbContext` to the service collection and configures it to use SQL Server as its database provider. The lambda expression passed to `AddDbContext` configures the DbContext options.

   - `options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))`: This configures the `AdventureWorkDbContext` to use a SQL Server database with a connection string named "DefaultConnection" retrieved from the application's configuration settings. This connection string specifies details like server location, database name, credentials, etc.

2. **Generic Repository Registration**:

   - `services.AddTransient(typeof(IRepositoryAsync<>), typeof(AdventureRepositoryAsync<>))`: This line registers a generic repository interface `IRepositoryAsync<>` with its implementation `AdventureRepositoryAsync<>` as a transient service. In dependency injection, transient services are created each time they are requested. This setup is typical for repository patterns where each request might require a fresh repository instance.

```c#
        public static void AddPersistenceInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AdventureWorkDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")
            ));

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(AdventureRepositoryAsync<>));
        }
```

---

</SwmSnippet>

<SwmSnippet path="/WebAPI/Program.cs" line="14">

---

This code snippet adds persistence infrastructure services to the DI container.

```c#
builder.Services.AddPersistenceInfra(configuration);
```

---

</SwmSnippet>

<SwmSnippet path="/Persistence/Repository/AdventureRepositoryAsync.cs" line="12">

---

`public class AdventureRepositoryAsync<T>`: Declares a public class named `AdventureRepositoryAsync` that takes a generic type `T`.

- `: RepositoryBase<T>, IRepositoryAsync<T>`: This class inherits from `RepositoryBase<T>` and implements the interface `IRepositoryAsync<T>`. This indicates that it provides basic repository functionalities (likely CRUD operations) and additional asynchronous operations defined in `IRepositoryAsync<T>`.

- `where T : class`: This is a constraint on the generic type `T`, specifying that `T` must be a class type. This constraint is often used in data access scenarios to ensure that the generic type can represent a database entity.

Overall, this class is designed to serve as a repository for entities of type T using the AdventureWorks database context (AdventureWorkDbContext). Repositories are used in software design to encapsulate the logic required to access data sources, providing a more abstract interface to the data layer of an application. This particular repository is set up to handle asynchronous data operations, making it suitable for performance-sensitive environments like web applications where non-blocking operations are crucial.

```c#
    public class AdventureRepositoryAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly AdventureWorkDbContext _dbContext;
        
        public AdventureRepositoryAsync(AdventureWorkDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }
    }
```

---

</SwmSnippet>

&nbsp;

<SwmMeta version="3.0.0" repo-id="Z2l0aHViJTNBJTNBV2ViQVBJLU9uaW9uJTNBJTNBMTk1MExhYnM=" repo-name="WebAPI-Onion"><sup>Powered by [Swimm](https://app.swimm.io/)</sup></SwmMeta>
