---
title: BusinessValidationException
---
<SwmSnippet path="/Application/Exceptions/BusinessValidationException.cs" line="10">

---

\
The <SwmToken path="/Application/Exceptions/BusinessValidationException.cs" pos="10:5:5" line-data="    public class BusinessValidationException : Exception">`BusinessValidationException`</SwmToken> class is a custom exception type that extends the base <SwmToken path="/Application/Exceptions/BusinessValidationException.cs" pos="10:9:9" line-data="    public class BusinessValidationException : Exception">`Exception`</SwmToken> class, specifically designed to handle business logic validation errors in an application. This exception captures a list of error messages indicating why the validation failed, providing clear feedback on what went wrong.

```c#
    public class BusinessValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public BusinessValidationException(): base("Validation errors found")
        {
            Errors = new List<string>();
        }

        public BusinessValidationException(IEnumerable<ValidationFailure> failures): this()
        {
            foreach (var item in failures)
            {
                Errors.Add(item.ErrorMessage);
            }
        }
    }
```

---

</SwmSnippet>

**Usage**

<SwmSnippet path="Application/Beheaviors/ValidationBehavior.cs" line="25">

---

This code snippet checks if there are any validation failures. If there are, it throws a custom exception with the list of validation failures.

```
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Any())
                {
                    //Custom exception to return list of validation failures
                    throw new Exceptions.BusinessValidationException(failures);
                }
```

---

</SwmSnippet>

<SwmMeta version="3.0.0" repo-id="Z2l0aHViJTNBJTNBV2ViQVBJLU9uaW9uJTNBJTNBMTk1MExhYnM=" repo-name="WebAPI-Onion"><sup>Powered by [Swimm](https://app.swimm.io/)</sup></SwmMeta>
