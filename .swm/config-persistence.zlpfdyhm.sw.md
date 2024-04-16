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

<SwmMeta version="3.0.0" repo-id="Z2l0aHViJTNBJTNBV2ViQVBJLU9uaW9uJTNBJTNBMTk1MExhYnM=" repo-name="WebAPI-Onion"><sup>Powered by [Swimm](https://app.swimm.io/)</sup></SwmMeta>
