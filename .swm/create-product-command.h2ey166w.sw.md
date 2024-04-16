---
title: Create Product Command
---
<SwmSnippet path="Application/Features/Products/Commands/CreateProductCommand/CreateProductCommand.cs" line="36">

---

This code snippet is a class `CreateProductCommandHandler` that implements the `IRequestHandler` interface. It handles the `CreateProductCommand` request and returns a `Response<int>`. The class has two dependencies injected through the constructor: `IRepositoryAsync<Product> repository` and `IMapper mapper`. The `repository` is used to perform CRUD operations on the `Product` entity, while the `mapper` is used for object mapping.

\
The `CreateProductCommandHandler` class is designed for handling product creation commands within a CQRS architecture, which separates read and write operations to enhance maintainability and scalability. It uses dependency injection to incorporate services for data manipulation (`IRepositoryAsync<Product>`) and object mapping (`IMapper`). This setup is common in applications that require decoupled logic and streamlined data handling.

**MediatR** is a .NET library that implements the mediator pattern, facilitating object interactions by acting as a communication hub. In this pattern, instead of components calling each other directly, they send messages or commands via the mediator, which then routes these to the appropriate handlers. This reduces dependencies among components, simplifying modifications and enhancements.

In the context of `CreateProductCommandHandler`:

- **MediatR Role**: MediatR manages the routing of `CreateProductCommand` objects to the appropriate handler (`CreateProductCommandHandler`). When a command is issued, MediatR ensures that it reaches `CreateProductCommandHandler`, which then processes it.

- **How It's Used**: The class implements `IRequestHandler<CreateProductCommand, Response<int>>`, a MediatR interface that defines a handler responsible for processing messages or commands and returning responses. The handler abstracts the creation logic, ensuring that any `CreateProductCommand` is handled appropriately, typically by validating the command, executing the creation logic, and then returning the result.

Overall, MediatR helps to organize code around behaviors and ensures that each component remains ignorant of the others, merely communicating through commands and events. This pattern is particularly useful in complex systems with many interacting components.

```
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Response<int>>
    {
        private readonly IRepositoryAsync<Product> _repository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IRepositoryAsync<Product> repository, IMapper mapper)
        {
            this._repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var data = await _repository.AddAsync(product);

            return new Response<int>(data.ProductId);
        }
    }
```

---

</SwmSnippet>

Usage

<SwmSnippet path="/WebAPI/Controllers/v1/ProductController.cs" line="17">

---

This code snippet is a method called <SwmToken path="/WebAPI/Controllers/v1/ProductController.cs" pos="17:10:10" line-data="        public async Task&lt;IActionResult&gt; Post(CreateProductCommand product)">`Post`</SwmToken> which is an asynchronous method that accepts a <SwmToken path="/Application/Features/Products/Commands/CreateProductCommand/CreateProductCommand.cs" pos="36:11:11" line-data="    public class CreateProductCommandHandler : IRequestHandler&lt;CreateProductCommand, Response&lt;int&gt;&gt;">`CreateProductCommand`</SwmToken> object as a parameter. It returns an <SwmToken path="/WebAPI/Controllers/v1/ProductController.cs" pos="17:7:7" line-data="        public async Task&lt;IActionResult&gt; Post(CreateProductCommand product)">`IActionResult`</SwmToken> object. Inside the method, it calls a <SwmToken path="/WebAPI/Controllers/v1/ProductController.cs" pos="19:9:9" line-data="            return Ok(await Mediator.Send(product));">`Send`</SwmToken> method of a `Mediator` object passing the `product` parameter and waits for the result. The result is then wrapped in an `Ok` response and returned.

```c#
        public async Task<IActionResult> Post(CreateProductCommand product)
        {
            return Ok(await Mediator.Send(product));
        }
```

---

</SwmSnippet>

<SwmSnippet path="/Application/Features/Products/Commands/CreateProductCommand/CreateProductCommand.cs" line="9">

---

This code snippet is a class definition named `CreateProductCommand` that implements the `IRequest` interface with a generic type `Response<int>`. It represents a command to create a product and expects a response of type `int`.

Is a DTO used to send Product information from Frontend.

```c#
    public class CreateProductCommand : IRequest<Response<int>>
    {
```

---

</SwmSnippet>

<SwmMeta version="3.0.0" repo-id="Z2l0aHViJTNBJTNBV2ViQVBJLU9uaW9uJTNBJTNBMTk1MExhYnM=" repo-name="WebAPI-Onion"><sup>Powered by [Swimm](https://app.swimm.io/)</sup></SwmMeta>
