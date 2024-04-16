---
title: Return Paginated Results
---
<SwmSnippet path="/WebAPI/Controllers/v1/ProductController.cs" line="46">

---

This code snippet is a GET endpoint for retrieving products. It accepts a query parameter `filter` of type `GetAllProductParameters`. The endpoint uses Mediator pattern to send a `GetAllProductsQuery` with the specified `PageNumber`, `PageSize`, and `SubCategoryId` to fetch the corresponding products. The response is returned as an `Ok` result.

```c#
        //GET api/<controller>/1
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllProductsQuery { PageNumber = filter.PageNumber, PageSize = filter.PageSize, SubCategoryId = filter.SubCategoryId }));
        }
```

---

</SwmSnippet>

<SwmSnippet path="/Application/Features/Products/Queries/GetAllProductsQuery/GetAllProductsQuery.cs" line="28">

---

This code snippet handles a query to retrieve all products. It uses a `PagedProductSpecification` to filter the products based on the page size, page number, and subcategory ID. It then maps the filtered products to `ProductDTO` objects using `_mapper`. Finally, it returns a paged response containing the list of `ProductDTO` objects, the page number, and the page size.

```c#
            public async Task<PagedResponse<List<ProductDTO>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
            {
                var products = await _repository.ListAsync(new PagedProductSpecification(request.PageSize, request.PageNumber, request.SubCategoryId));
                var productsDTO = _mapper.Map<List<ProductDTO>>(products);

                return new PagedResponse<List<ProductDTO>>(productsDTO, request.PageNumber, request.PageSize);
            }
```

---

</SwmSnippet>

<SwmMeta version="3.0.0" repo-id="Z2l0aHViJTNBJTNBV2ViQVBJLU9uaW9uJTNBJTNBMTk1MExhYnM=" repo-name="WebAPI-Onion"><sup>Powered by [Swimm](https://app.swimm.io/)</sup></SwmMeta>
