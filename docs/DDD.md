# Domain-Driven Design (DDD)

### Introduction to DDD
Domain-Driven Design (DDD) is an approach to software development that centers on understanding and modeling the core business domain. It aims to create a rich domain model that captures the essence of the business logic, making the code more maintainable and easier to align with changes in business requirements. In the context of a .NET Boilerplate Web API, DDD helps structure the application to ensure scalability and maintainability, particularly when dealing with complex business processes.

### DDD Components and Examples
DDD involves several key components, each with specific roles. Below are explanations and examples in C# for a .NET project:

- **Entities**: These are objects with identity and state, such as a `Customer` or `Order`. They have methods to encapsulate behavior.
  - Example:
    ```cs
    public class Customer : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }
    }
    ```

- **Value Objects**: These are objects defined by their attributes, not by identity, such as an `Address`. They are immutable and used to describe things like locations or monetary values.
  - Example:
    ```cs
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string Country { get; }
        public Address(string street, string city, string country)
        {
            Street = street;
            City = city;
            Country = country;
        }
    }
    ```

- **Aggregates**: These are groups of objects treated as a single unit for data consistency, with one entity as the aggregate root (e.g., `Order` with `OrderItem`).
  - Example:
    ```cs
    public class Order : Entity, IAggregateRoot
    {
        public int CustomerId { get; private set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();
        public decimal Subtotal => Items.Sum(item => item.Price * item.Quantity);
        public decimal ShippingCost { get; private set; }
        public decimal Total => Subtotal + ShippingCost;
        public Order(int customerId)
        {
            CustomerId = customerId;
        }
        public void AddItem(string productName, int quantity, decimal price)
        {
            var item = new OrderItem(productName, quantity, price);
            Items.Add(item);
        }
        public void SetShippingCost(decimal shippingCost)
        {
            ShippingCost = shippingCost;
        }
    }
    ```

- **Domain Services**: These encapsulate business logic that doesn't fit neatly into an entity or value object, such as calculating shipping costs.
  - Example:
    ```cs
    public class ShippingService
    {
        public decimal CalculateShippingCost(Address destination)
        {
            // Simple example: fixed shipping cost
            return 10.0m;
        }
    }
    ```

- **Factories**: Used for creating complex objects, though not detailed here for brevity, they help encapsulate creation logic.
- **Repositories**: Abstract data access, defined in the domain layer and implemented in the infrastructure layer.
  - Example:
    ```cs
    public interface IOrderRepository
    {
        Order GetById(int id);
        void Add(Order order);
    }
    ```

### Project Organization
The .NET Boilerplate Web API is structured into layers following Clean Architecture, each with specific responsibilities:

- **Domain Layer**: Contains entities, value objects, aggregates, domain services, and repository interfaces. This layer is independent of external frameworks.
- **Application Layer**: Handles use cases, commands, and queries, often using CQRS (Command Query Responsibility Segregation). It orchestrates interactions between the domain and infrastructure layers.
- **Infrastructure Layer**: Implements repository interfaces and handles external concerns like databases, using technologies like Entity Framework Core.
- **Presentation Layer**: Exposes the API via controllers, handling HTTP requests and delegating to the application layer.

### Practical Implementation
For a complete example, consider a use case like placing an order:

- **Domain Layer**: Define `Customer`, `Order`, `OrderItem`, and `ShippingService` as shown above.
- **Application Layer**: Implement a `PlaceOrderCommand` and handler:
  ```cs
  public class PlaceOrderCommand
  {
      public int CustomerId { get; set; }
      public List<OrderItem> Items { get; set; }
  }
  public class PlaceOrderCommandHandler
  {
      private readonly ICustomerRepository _customerRepository;
      private readonly IOrderRepository _orderRepository;
      private readonly ShippingService _shippingService;
      public PlaceOrderCommandHandler(ICustomerRepository customerRepository, IOrderRepository orderRepository, ShippingService shippingService)
      {
          _customerRepository = customerRepository;
          _orderRepository = orderRepository;
          _shippingService = shippingService;
      }
      public async Task Handle(PlaceOrderCommand command)
      {
          var customer = await _customerRepository.GetById(command.CustomerId);
          if (customer == null) throw new Exception("Customer not found");
          var order = new Order(command.CustomerId);
          foreach (var item in command.Items)
          {
              order.AddItem(item.ProductName, item.Quantity, item.Price);
          }
          var shippingCost = _shippingService.CalculateShippingCost(customer.Address);
          order.SetShippingCost(shippingCost);
          await _orderRepository.Add(order);
      }
  }
  ```
- **Infrastructure Layer**: Implement repositories using Entity Framework Core, such as `CustomerRepository` and `OrderRepository`, with a `DbContext` for database operations.
- **Presentation Layer**: Create API controllers to handle HTTP requests, like a `POST /api/orders` endpoint.

### Testing and Deployment
- **Testing**: Unit tests for domain logic (e.g., `Order.CalculateTotal`), integration tests for repository implementations, and end-to-end tests for API workflows.
- **Deployment**: Build the project with `dotnet build --configuration Release`, publish with `dotnet publish`, and deploy to a hosting environment like IIS or Docker, ensuring environment variables (e.g., database connections) are configured.

---

### Comprehensive Survey Note on DDD with .NET

This section provides a detailed exploration of Domain-Driven Design (DDD) within the context of a .NET Boilerplate Web API, expanding on the direct answer with additional depth and technical details. It aims to mimic a professional article, covering all aspects discussed in the thinking trace and ensuring a strict superset of the content provided above.

#### Introduction to Domain-Driven Design
Domain-Driven Design (DDD), as conceptualized by Eric Evans, is a methodology for modeling complex business domains effectively. It emphasizes a deep understanding of the domain, ensuring that the software model reflects the real-world business processes. In the .NET ecosystem, particularly with a Boilerplate Web API, DDD is implemented to create scalable, maintainable applications by aligning code with business needs. This approach is especially relevant for systems where business logic is intricate, such as e-commerce platforms or financial systems.

The thinking trace highlights DDD's focus on capturing the language and rules of the business, which translates to creating a rich domain model in .NET. This model is independent of technical details, ensuring that changes in infrastructure (e.g., database) do not affect the core business logic.

#### Key DDD Components and Their Implementation
DDD comprises several components, each with specific roles. Below, we detail each component with examples in C#, reflecting the thinking trace's exploration:

##### Entities
Entities are objects with a unique identity and lifecycle, such as a `Customer` or `Order`. They encapsulate state and behavior, ensuring that business rules are enforced within the object. The thinking trace suggests defining a base `Entity` class with an ID for consistency:
- Example:
  ```cs
  public abstract class Entity
  {
      public int Id { get; protected set; }
  }
  public class Customer : Entity
  {
      public string Name { get; private set; }
      public string Email { get; private set; }
      public Address Address { get; private set; }
      public Customer(string name, string email, Address address)
      {
          Name = name;
          Email = email;
          Address = address;
      }
  }
  ```
  This ensures immutability where appropriate and encapsulates behavior, aligning with DDD principles.

##### Value Objects
Value objects are defined by their attributes, not identity, and are immutable. Examples include `Address` or `Money`. The thinking trace notes their immutability, which is crucial for maintaining consistency:
- Example:
  ```cs
  public class Address
  {
      public string Street { get; }
      public string City { get; }
      public string Country { get; }
      public Address(string street, string city, string country)
      {
          Street = street;
          City = city;
          Country = country;
      }
  }
  ```
  The thinking trace explores how `Address` might be used within `Customer`, ensuring it reflects business rules like validation.

##### Aggregates
Aggregates are groups of objects treated as a single unit for data consistency, with one entity as the aggregate root. The thinking trace discusses `Order` as an aggregate root, potentially including `OrderItem`. It notes the challenge of deciding whether `OrderItem` is an entity or value object:
- Example:
  ```cs
  public class Order : Entity, IAggregateRoot
  {
      public int CustomerId { get; private set; }
      public List<OrderItem> Items { get; private set; } = new List<OrderItem>();
      public decimal Subtotal => Items.Sum(item => item.Price * item.Quantity);
      public decimal ShippingCost { get; private set; }
      public decimal Total => Subtotal + ShippingCost;
      public Order(int customerId)
      {
          CustomerId = customerId;
      }
      public void AddItem(string productName, int quantity, decimal price)
      {
          var item = new OrderItem(productName, quantity, price);
          Items.Add(item);
      }
      public void SetShippingCost(decimal shippingCost)
      {
          ShippingCost = shippingCost;
      }
  }
  public class OrderItem
  {
      public string ProductName { get; }
      public int Quantity { get; }
      public decimal Price { get; }
      public OrderItem(string productName, int quantity, decimal price)
      {
          ProductName = productName;
          Quantity = quantity;
          Price = price;
      }
  }
  ```
  The thinking trace debates whether `OrderItem` should have an ID, concluding it can be a value object for simplicity, with Entity Framework Core (EF Core) handling persistence via owned types.

##### Domain Services
Domain services encapsulate business logic that spans multiple entities or aggregates, such as calculating shipping costs. The thinking trace explores whether logic like shipping cost calculation belongs in the domain layer, concluding it should be pure and not depend on infrastructure:
- Example:
  ```cs
  public class ShippingService
  {
      public decimal CalculateShippingCost(Address destination)
      {
          // Simple example: fixed shipping cost
          return 10.0m;
      }
  }
  ```
  The thinking trace notes that the application layer might pass necessary data (e.g., address) to the domain layer, keeping it independent.

##### Factories
Factories are used for creating complex objects, encapsulating creation logic. The thinking trace provides an example:
- Example:
  ```cs
  public class OrderFactory
  {
      public Order CreateOrder(int customerId, List<OrderItem> items, decimal shippingCost)
      {
          var order = new Order(customerId);
          order.Items = items;
          order.SetShippingCost(shippingCost);
          return order;
      }
  }
  ```
  While not always necessary for simple cases, factories help in complex scenarios.

##### Repositories
Repositories abstract data access, defined in the domain layer and implemented in the infrastructure layer. The thinking trace emphasizes keeping the domain layer pure:
- Example:
  ```cs
  public interface IOrderRepository
  {
      Order GetById(int id);
      void Add(Order order);
  }
  ```
  The infrastructure layer implements this using EF Core, as seen in the thinking trace:
  ```cs
  public class OrderRepository : IOrderRepository
  {
      private readonly DbContext _context;
      public OrderRepository(DbContext context)
      {
          _context = context;
      }
      public async Task<Order> GetById(int id)
      {
          return await _context.Orders.Include(o => o.Items).FirstAsync(o => o.Id == id);
      }
      public async Task Add(Order order)
      {
          _context.Orders.Add(order);
          await _context.SaveChangesAsync();
      }
  }
  ```

##### Bounded Contexts
The thinking trace mentions bounded contexts, which are subdomains with their own models. For example, in an e-commerce system, you might have:
- Customer Context: Handles customer registration.
- Order Context: Manages order placement.
- In .NET, this could mean separate assemblies, organized by context, ensuring clarity and reducing model conflicts.

#### Project Organization and Layers
The thinking trace outlines a Clean Architecture structure, which is standard for DDD in .NET:
- **Domain Project**: Class library with entities, value objects, aggregates, domain services, and repository interfaces.
- **Application Project**: Class library with use cases, commands, and queries, often using libraries like MediatR for CQRS.
- **Infrastructure Project**: Class library with repository implementations, external services, and database configurations.
- **WebApi Project**: The ASP.NET Core project exposing API endpoints, delegating to the application layer.

This structure ensures separation of concerns, with dependencies pointing inward toward the domain layer, adhering to the Dependency Inversion Principle.

#### Practical Implementation Example
The thinking trace provides a complete example of placing an order, which we expand here:
- **Domain Layer**: As shown above, with `Customer`, `Order`, `OrderItem`, and `ShippingService`.
- **Application Layer**: The `PlaceOrderCommand` and handler, using dependency injection:
  ```cs
  public class PlaceOrderCommandHandler
  {
      // As shown in the direct answer, with repository and service dependencies.
  }
  ```
- **Infrastructure Layer**: Implements repositories using EF Core, with a `DbContext` configuration:
  ```cs
  public class ApplicationDbContext : DbContext
  {
      public DbSet<Customer> Customers { get; set; }
      public DbSet<Order> Orders { get; set; }
      protected override void OnModelCreating(ModelBuilder builder)
      {
          builder.Entity<Customer>(b =>
          {
              b.HasKey(c => c.Id);
              b.Property(c => c.Name).IsRequired();
              b.Property(c => c.Email).IsRequired();
              b.OwnsOne(c => c.Address);
          });
          builder.Entity<Order>(b =>
          {
              b.HasKey(o => o.Id);
              b.Property(o => o.CustomerId).IsRequired();
              b.OwnsMany(o => o.Items, a =>
              {
                  a.Property(i => i.ProductName).IsRequired();
                  a.Property(i => i.Quantity).IsRequired();
                  a.Property(i => i.Price).IsRequired();
              });
          });
      }
  }
  ```
  The thinking trace discusses challenges with persisting value objects like `OrderItem`, resolving it with EF Core's `OwnsMany` for collections.

- **Presentation Layer**: API controllers, such as:
  ```cs
  [ApiController]
  [Route("api/[controller]")]
  public class OrdersController : ControllerBase
  {
      private readonly IMediator _mediator;
      public OrdersController(IMediator mediator)
      {
          _mediator = mediator;
      }
      [HttpPost]
      public async Task<IActionResult> CreateOrder([FromBody] PlaceOrderCommand command)
      {
          await _mediator.Send(command);
          return Ok();
      }
  }
  ```
  This uses MediatR for command handling, as suggested in the thinking trace.

#### Testing Strategies
The thinking trace emphasizes testing, with:
- **Unit Tests**: For domain logic, e.g., testing `Order.CalculateTotal`:
  ```cs
  [Test]
  public void Order_CalculateTotal_ReturnsCorrectValue()
  {
      var order = new Order(1);
      order.AddItem("Book", 2, 10.0m);
      order.SetShippingCost(5.0m);
      Assert.AreEqual(25.0m, order.Total);
  }
  ```
- **Integration Tests**: For repository implementations, ensuring data access works with the database.
- **End-to-End Tests**: For API workflows, testing the entire stack from HTTP request to database persistence.

#### Deployment Procedures
Deployment, as per the thinking trace, involves:
- Building with `dotnet build --configuration Release`.
- Publishing with `dotnet publish --configuration Release --output ./publish`.
- Deploying to a hosting environment, such as IIS, Kestrel, or Docker:
  ```dockerfile
  FROM mcr.microsoft.com/dotnet/aspnet:6.0
  COPY ./publish /app
  WORKDIR /app
  ENTRYPOINT ["dotnet", "Presentation.dll"]
  ```
- Configuring environment variables, like database connection strings, in `appsettings.json` or via environment settings.

#### Additional Considerations
The thinking trace explores challenges, such as deciding whether `OrderItem` is an entity or value object, and how to handle persistence. It concludes that for simplicity, `OrderItem` can be a value object with EF Core's `OwnsMany`, ensuring the domain layer remains pure. It also notes the importance of dependency injection, using Microsoft's DI in ASP.NET Core:
- Example in `Program.cs`:
  ```cs
  builder.Services.AddDbContext<ApplicationDbContext>();
  builder.Services.AddTransient<IOrderRepository, OrderRepository>();
  builder.Services.AddTransient<ShippingService>();
  ```

This comprehensive approach ensures the documentation covers all aspects, from theory to practical implementation, aligning with the thinking trace's exploration.

#### Table: Summary of DDD Components and Layers

| Component/Layer        | Description                                      | Example in .NET                     |
|-----------------------|--------------------------------------------------|-------------------------------------|
| Entities              | Objects with identity and state                  | `Customer`, `Order`                 |
| Value Objects         | Immutable objects defined by attributes          | `Address`, `OrderItem`              |
| Aggregates            | Groups treated as a single unit for consistency  | `Order` with `OrderItem` list       |
| Domain Services       | Logic spanning multiple entities                 | `ShippingService`                   |
| Repositories          | Abstract data access                            | `IOrderRepository` interface        |
| Domain Layer          | Core business logic, framework-independent       | Domain project with entities        |
| Application Layer     | Use cases and commands                          | `PlaceOrderCommandHandler`          |
| Infrastructure Layer  | Data access implementations                     | `OrderRepository` with EF Core      |
| Presentation Layer    | API endpoints                                   | `OrdersController` in WebApi project|

This table summarizes the key components and layers, enhancing readability and organization.

#### Conclusion
By adhering to DDD principles in a .NET Boilerplate Web API, developers can create scalable, maintainable systems that align with business needs. The thinking trace's detailed exploration ensures this documentation covers all aspects, from theoretical concepts to practical implementation, providing a robust guide for implementation.

---

### Key Citations
- [Domain-Driven Design Overview](https://en.wikipedia.org/wiki/Domain-driven_design)
- [Clean Architecture Software Design](https://en.wikipedia.org/wiki/Clean_Architecture_(software))
- [Command Query Responsibility Segregation](https://en.wikipedia.org/wiki/Command_query_separation)