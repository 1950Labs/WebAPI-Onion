---
title: Config mappings using AutoMapper
---
<SwmSnippet path="/Application/Mappings/GeneralProfile.cs" line="8">

---

This code snippet defines a class `GeneralProfile` that extends the `Profile` class. It has a constructor that creates mappings between `CreateProductCommand` and `Product` and between `Product` and `ProductDTO`.

```c#
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, ProductDTO>();
        }
    }
```

---

</SwmSnippet>

&nbsp;

<SwmMeta version="3.0.0" repo-id="Z2l0aHViJTNBJTNBV2ViQVBJLU9uaW9uJTNBJTNBMTk1MExhYnM=" repo-name="WebAPI-Onion"><sup>Powered by [Swimm](https://app.swimm.io/)</sup></SwmMeta>
