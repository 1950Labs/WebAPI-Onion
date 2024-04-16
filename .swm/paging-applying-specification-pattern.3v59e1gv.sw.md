---
title: 'Paging applying Specification Pattern '
---
<SwmSnippet path="/Application/Specifications/PagedProductSpecification.cs" line="6">

---

This code define a custom specification to apply paiging.

This code snippet defines a `PagedProductSpecification` class that extends the `Specification<Product>` class. It takes in parameters for `pageSize`, `pageNumber`, and `subcategoryId`. The constructor calculates the `skip` value based on the `pageNumber` and `pageSize`. It then uses the `Query` object to skip the calculated number of items and take the specified `pageSize`. If `subcategoryId` is provided and greater than 0, it adds a condition to the query to filter by `ProductSubcategoryId`. Finally, it orders the query results by `ProductId` in descending order.

```c#
    public class PagedProductSpecification : Specification<Product>
    {
        public PagedProductSpecification(int pageSize, int pageNumber, int? subcategoryId)
        {
            int skip = (pageNumber - 1) * pageSize;

            Query.Skip(skip).Take(pageSize);

            if(subcategoryId.HasValue && subcategoryId.Value > 0)
            {
                Query.Where(x => x.ProductSubcategoryId.Equals(subcategoryId));
            }

            Query.OrderByDescending(x => x.ProductId);
        }
    }
```

---

</SwmSnippet>

**Ardalis** <SwmToken path="/Application/Specifications/PagedProductSpecification.cs" pos="6:9:9" line-data="    public class PagedProductSpecification : Specification&lt;Product&gt;">`Specification`</SwmToken>

In .NET 6, as in other versions of .NET, `Ardalis.Specification` is a library designed to encapsulate the business logic used to retrieve data from a database into a separate specification instead of scattering it throughout the application. It adheres to the Specification Pattern, which helps in crafting queries in a reusable and maintainable manner. The library is typically used with Entity Framework but can be adapted to work with other data access technologies.

### **Key Features of Ardalis.Specification:**

- **Separation of Concerns**: It allows you to separate query logic from the business logic in your application. Specifications define the "what" to fetch, and the repository uses these specifications to determine "how" to fetch it.

- **Reusability**: You can define a specification once and use it across multiple queries or repository methods, avoiding code duplication and improving maintainability.

- **Decoupling**: Specifications can be used in application layers without depending directly on the specific ORM (Object-Relational Mapper) being used, making it easier to switch implementations or to unit test application logic without the database.

### **Components of Ardalis.Specification:**

- **Specification**: This is a base class that you can inherit to create your own specifications. A specification typically includes criteria (e.g., filters, sorting instructions), includes (related entities to fetch), and may specify paging parameters.

- **Evaluator**: This component applies a specification to an `IQueryable` source. It translates the specification into the query that Entity Framework can execute.

- **Repository Interface**: The library often is used alongside a generic repository pattern. While not strictly required, this pattern fits well with the use of specifications to encapsulate all data access logic.

- **Repository Implementation**: This might use the specifications to craft queries using Entity Framework, execute them, and return results.

### **How It Works:**

1. **Define a Specification**: You define a class that extends `Specification<T>` where `T` is the entity type you are querying. In this class, you specify the conditions of the query—filters, includes, ordering, etc.

2. **Use in Repository**: In your repository, you accept specifications as parameters to methods that execute queries. The repository uses the specification to build and execute a query using Entity Framework.

3. **Execution**: When a method in your repository is called with a specification, it uses the evaluator to apply the specification to an `IQueryable`. The query is then executed against the database, and the results are returned.

<SwmMeta version="3.0.0" repo-id="Z2l0aHViJTNBJTNBV2ViQVBJLU9uaW9uJTNBJTNBMTk1MExhYnM=" repo-name="WebAPI-Onion"><sup>Powered by [Swimm](https://app.swimm.io/)</sup></SwmMeta>
