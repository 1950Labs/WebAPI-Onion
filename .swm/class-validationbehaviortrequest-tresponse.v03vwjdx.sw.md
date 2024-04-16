---
title: 'Class: ValidationBehavior<TRequest, TResponse>'
---
<SwmSnippet path="/Application/Beheaviors/ValidationBehavior.cs" line="6">

---

This code snippet is a class named <SwmToken path="/Application/Beheaviors/ValidationBehavior.cs" pos="6:5:5" line-data="    public class ValidationBehavior&lt;TRequest, TResponse&gt; : IPipelineBehavior&lt;TRequest, TResponse&gt; where TRequest : IRequest&lt;TResponse&gt;">`ValidationBehavior`</SwmToken> that implements the <SwmToken path="/Application/Beheaviors/ValidationBehavior.cs" pos="6:15:15" line-data="    public class ValidationBehavior&lt;TRequest, TResponse&gt; : IPipelineBehavior&lt;TRequest, TResponse&gt; where TRequest : IRequest&lt;TResponse&gt;">`IPipelineBehavior`</SwmToken> interface to add validation logic to the handling of requests within a pipeline. It is a generic class that takes two type parameters <SwmToken path="/Application/Beheaviors/ValidationBehavior.cs" pos="6:7:7" line-data="    public class ValidationBehavior&lt;TRequest, TResponse&gt; : IPipelineBehavior&lt;TRequest, TResponse&gt; where TRequest : IRequest&lt;TResponse&gt;">`TRequest`</SwmToken> and <SwmToken path="/Application/Beheaviors/ValidationBehavior.cs" pos="6:10:10" line-data="    public class ValidationBehavior&lt;TRequest, TResponse&gt; : IPipelineBehavior&lt;TRequest, TResponse&gt; where TRequest : IRequest&lt;TResponse&gt;">`TResponse`</SwmToken>. The <SwmToken path="/Application/Beheaviors/ValidationBehavior.cs" pos="6:7:7" line-data="    public class ValidationBehavior&lt;TRequest, TResponse&gt; : IPipelineBehavior&lt;TRequest, TResponse&gt; where TRequest : IRequest&lt;TResponse&gt;">`TRequest`</SwmToken> type parameter must implement the <SwmToken path="/Application/Beheaviors/ValidationBehavior.cs" pos="6:29:32" line-data="    public class ValidationBehavior&lt;TRequest, TResponse&gt; : IPipelineBehavior&lt;TRequest, TResponse&gt; where TRequest : IRequest&lt;TResponse&gt;">`IRequest<TResponse>`</SwmToken> interface.

&nbsp;

```c#
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
```

---

</SwmSnippet>

<SwmSnippet path="/Application/Beheaviors/ValidationBehavior.cs" line="15">

---

This code snippet handles the validation of a request by executing defined validations and throwing a custom exception if any validation failures occur.

```c#
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                //execute defained validations
                var validationResults = await Task.WhenAll(_validators.Select(x => x.ValidateAsync(context, cancellationToken)));

                //Get validation failures list
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                {
                    //Custom exception to return list of validation failures
                    throw new Exceptions.BusinessValidationException(failures);
                }
            }

            return await next();
        }
```

---

</SwmSnippet>

<SwmSnippet path="/Application/ServiceExtensions.cs" line="34">

---

This code snippet registers a transient service to the Dependency Injection container. It specifies that the <SwmToken path="/Application/Beheaviors/ValidationBehavior.cs" pos="6:5:5" line-data="    public class ValidationBehavior&lt;TRequest, TResponse&gt; : IPipelineBehavior&lt;TRequest, TResponse&gt; where TRequest : IRequest&lt;TResponse&gt;">`ValidationBehavior`</SwmToken> class should be used as a pipeline behavior for all implementations of the <SwmToken path="/Application/Beheaviors/ValidationBehavior.cs" pos="6:15:15" line-data="    public class ValidationBehavior&lt;TRequest, TResponse&gt; : IPipelineBehavior&lt;TRequest, TResponse&gt; where TRequest : IRequest&lt;TResponse&gt;">`IPipelineBehavior`</SwmToken> interface.

```c#
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
```

---

</SwmSnippet>

<SwmSnippet path="/WebAPI/Program.cs" line="13">

---

This code snippet adds the `ApplicationLayer` to the services container.

```c#
builder.Services.AddApplicationLayer();
```

---

</SwmSnippet>

<SwmMeta version="3.0.0" repo-id="Z2l0aHViJTNBJTNBV2ViQVBJLU9uaW9uJTNBJTNBMTk1MExhYnM=" repo-name="WebAPI-Onion"><sup>Powered by [Swimm](https://app.swimm.io/)</sup></SwmMeta>
