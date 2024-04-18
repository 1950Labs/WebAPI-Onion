---
title: Config mappings using AutoMapper
---
<SwmSnippet path="/Application/Mappings/GeneralProfile.cs" line="8">

---

This code snippet defines a class <SwmToken path="/Application/Mappings/GeneralProfile.cs" pos="8:5:5" line-data="    public class GeneralProfile : Profile">`GeneralProfile`</SwmToken> that extends the <SwmToken path="/Application/Mappings/GeneralProfile.cs" pos="8:9:9" line-data="    public class GeneralProfile : Profile">`Profile`</SwmToken> class. It has a constructor that creates mappings between <SwmToken path="/Application/Mappings/GeneralProfile.cs" pos="12:3:3" line-data="            CreateMap&lt;CreateProductCommand, Product&gt;();">`CreateProductCommand`</SwmToken> and <SwmToken path="/Domain/Entities/Product.cs" pos="11:3:3" line-data="        public Product()">`Product`</SwmToken> and between <SwmToken path="/Domain/Entities/Product.cs" pos="11:3:3" line-data="        public Product()">`Product`</SwmToken> and <SwmToken path="/Application/DTOs/ProductDTO.cs" pos="9:5:5" line-data="    public class ProductDTO">`ProductDTO`</SwmToken>.

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
