---
title: Api Versioning
---
<SwmSnippet path="/WebAPI/Extensions/ServiceExtensions.cs" line="5">

---

This code snippet adds API versioning extension to the `IServiceCollection` in an [ASP.NET](http://ASP.NET) Core application. It configures the default API version, assumes the default version when unspecified, and enables reporting of API versions.

- **DefaultApiVersion (new** <SwmToken path="/WebAPI/Extensions/ServiceExtensions.cs" pos="9:9:18" line-data="                config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);">`Microsoft.AspNetCore.Mvc.ApiVersion(1,`</SwmToken> **0))**: This setting establishes the default API version as 1.0. When clients do not specify a version in their requests, this default version is used automatically.

- <SwmToken path="/WebAPI/Extensions/ServiceExtensions.cs" pos="10:3:3" line-data="                config.AssumeDefaultVersionWhenUnspecified = true;">`AssumeDefaultVersionWhenUnspecified`</SwmToken> **(true)**: With this setting enabled, if a client request does not include a version number, the API will assume the default version. This helps to prevent breaking existing clients when versioning is introduced after the API is already in use.

- <SwmToken path="/WebAPI/Extensions/ServiceExtensions.cs" pos="11:3:3" line-data="                config.ReportApiVersions = true;">`ReportApiVersions`</SwmToken> **(true)**: This option configures the API to include headers in its responses that list the versions available for the used API. This is useful for clients to know which versions are supported and might encourage clients to move to newer versions.

```c#
        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
```

---

</SwmSnippet>

<SwmSnippet path="/WebAPI/Program.cs" line="16">

---

This code snippet adds an API versioning extension to the service collection.

```c#
builder.Services.AddApiVersioningExtension();
```

---

</SwmSnippet>

<SwmSnippet path="/WebAPI/Controllers/v1/ProductController.cs" line="12">

---

This code snippet is a class definition for a `ProductController` class that extends `BaseApiController`. It is annotated with `ApiVersion("1.0")`.

```c#
    [ApiVersion("1.0")]
    public class ProductController : BaseApiController
    {
```

---

</SwmSnippet>

<SwmMeta version="3.0.0" repo-id="Z2l0aHViJTNBJTNBV2ViQVBJLU9uaW9uJTNBJTNBMTk1MExhYnM=" repo-name="WebAPI-Onion"><sup>Powered by [Swimm](https://app.swimm.io/)</sup></SwmMeta>
