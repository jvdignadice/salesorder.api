
### Architectural Principles

- **Separation of Concerns:** Controllers → Services → Repositories → EF Core.
- **SOLID Principles:** Single Responsibility, Dependency Inversion via DI, Open/Closed design.
- **Dependency Injection:** Use built-in .NET DI for services, repositories, and DbContext.
- **Async/Await:** All database and file I/O operations should be asynchronous.

---

## Database Schema Design

### Core Entities

| Entity         | Description                                                | Relationships                           |
|----------------|------------------------------------------------------------|----------------------------------------|
| `Order`        | Represents a pizza order with timestamp and customer info | 1:N → OrderItems                        |
| `OrderItem`    | Individual pizza in an order                               | N:1 → Order, N:1 → PizzaVariant        |
| `PizzaType`    | Pizza category/type (e.g., BBQ Chicken, Margherita)       | 1:N → PizzaVariant                       |
| `PizzaVariant` | Size, price, ingredients of a pizza                        | N:1 → PizzaType, N:M → Ingredients      |
| `Ingredient`   | Pizza ingredient                                          | N:M → PizzaVariant                        |

### Normalization Rationale

- **Orders & OrderDetails:** Allows multiple pizzas per order, avoids data duplication.
- **PizzaType & Pizza:** Separates logical pizza categories from size/price variants.
- **Ingredients:** Normalized to handle reusable ingredient definitions.

### EF Core Considerations

- Use `HasKey` and `HasIndex` for primary and unique constraints.
- `decimal` for prices: `HasPrecision(10, 2)` to avoid rounding issues.
- Navigation properties for relationships.
- Separate `DbContext` configuration and avoid business logic inside it.

---

## CSV Import Process

### Design

- **CSV Parser:** Use `CsvHelper` or custom parser.
- **Validation:** Check required fields, correct types, duplicate detection.
- **Bulk Insert:** Use EF Core `AddRangeAsync` and `SaveChangesAsync` for efficiency.
- **Error Handling:** Log invalid rows, skip errors, continue import.
- **Idempotency:** Avoid duplicate imports based on unique keys (e.g., order ID + item).

---

### DB Script
- **DB Script:** I Added a folder inside the src folder for Database scripts of the Normalized table
- **DB Script:** it contains the schema structure of each table for storing csv to db.
- **Update-Database:** Update-Database -Project Infrastructure -StartupProject test.api.project.one -Context TestAppDbContext.



- **CSV Parser:** Use `CsvHelper` or custom parser.
- **Validation:** Check required fields, correct types, duplicate detection.
- **Bulk Insert:** Use EF Core `AddRangeAsync` and `SaveChangesAsync` for efficiency.
- **Error Handling:** Log invalid rows, skip errors, continue import.
- **Idempotency:** Avoid duplicate imports based on unique keys (e.g., order ID + item).

---

## API Design

### RESTful Endpoints

#### Orders

- `GET /api/orders?page=1&pageSize=50` - Paginated list of orders.
- `GET /api/orders/{id}` - Single order details including pizzas.
- `POST /api/orders/import` - Import CSV data.

#### Pizzas

- `GET /api/pizzas` - List all pizza types with variants.
- `GET /api/pizzas/{id}` - Details including sizes, prices, ingredients.

#### Analytics (Bonus)

- `GET /api/analytics/top-selling` - Top 10 pizzas by quantity.
- `GET /api/analytics/revenue` - Revenue trends by day/week/month.
- `GET /api/analytics/popular-ingredients` - Most used ingredients.

### API Best Practices

- Use HTTP status codes: `200 OK`, `400 Bad Request`, `500 Internal Server Error`.
- Use DTOs for API responses, never expose EF entities directly.
- Implement **global exception handling** middleware.
- Support **pagination, filtering, and sorting**.

---

## Testing Strategy

- Unit tests for:
  - CSV import validation
  - Repository methods
  - Services logic
- Integration tests for:
  - API endpoints
  - Data retrieval
  - Error handling
- Tools: `xUnit`, `Moq` / `FakeItEasy` for mocking.

---

## Performance Considerations

- **Bulk inserts** for CSV import to minimize database calls.
- **Indexes** on frequently queried columns (`OrderDate`, `PizzaTypeId`).
- Consider **caching** for analytics endpoints to reduce repeated computation.
- Async I/O for all database and file operations.

---

## Git & Delivery Best Practices

- Use **feature branches** for each task (e.g., `feature/csv-import`).
- Frequent, descriptive commits: `"Add CSV import service with validation"`.
- Clean, readable **README.md** including:
  - Setup instructions
  - Database schema diagram
  - API documentation
- Include **Postman collection** or **Swagger** for API testing.

---






