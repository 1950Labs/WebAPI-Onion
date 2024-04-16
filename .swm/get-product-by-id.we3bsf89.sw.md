---
title: Get Product by Id
---
<SwmSnippet path="/WebAPI/Controllers/v1/ProductController.cs" line="39">

---

This code snippet is a GET endpoint that retrieves a product by its `id` from an API controller. It uses the `HttpGet` attribute to specify the route template for the endpoint (`api/<controller>/1`). Inside the method, it calls `Mediator.Send` to send a `GetProductByIdQuery` with the specified `id` to the mediator and awaits the response. The response is then returned as an `Ok` result.

```c#
        //GET api/<controller>/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductByIdQuery { ProductId = id }));
        }
```

---

</SwmSnippet>

<SwmSnippet path="/Application/Features/Products/Queries/GetProductByIdQuery/GetProductByIdQuery.cs" line="25">

---

This code snippet handles a `GetProductByIdQuery` by retrieving a product from the `_repository` based on the `ProductId` provided. If the product is not found, a `KeyNotFoundException` is thrown. Otherwise, the retrieved product is mapped to a `ProductDTO` using `_mapper` and returned as a `Response<ProductDTO>`.

```c#
            public async Task<Response<ProductDTO>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
            {
                var product = await _repository.GetByIdAsync(request.ProductId);

                if (product == null)
                    throw new KeyNotFoundException($"Product { request.ProductId } not found");

                var productDto = _mapper.Map<ProductDTO>(product);
                return new Response<ProductDTO>(productDto);
            }
```

---

</SwmSnippet>

<SwmMeta version="3.0.0" repo-id="Z2l0aHViJTNBJTNBV2ViQVBJLU9uaW9uJTNBJTNBMTk1MExhYnM=" repo-name="WebAPI-Onion"><sup>Powered by [Swimm](https://app.swimm.io/)</sup></SwmMeta>
