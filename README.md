# nacre-backend

Minimal ASP.NET Core backend for managing customers, products, and orders.

## Tech stack
- .NET `10.0` (preview/RC packages)
- ASP.NET Core Minimal APIs
- Entity Framework Core + SQLite
- Swagger (Swashbuckle)

## Project structure
- `/Program.cs` app startup, DI, endpoint registration, and seed data
- `/MigrateDatabase` EF Core `DbContext`
- `/DatabaseEntity` entity models
- `/DataTransferObjects` request/response DTOs
- `/Handler` endpoint handlers, route setup, and mappers
- `/Migrations` EF Core migrations
- `/Database/MyPrototypeDb.db` SQLite database file

## Prerequisites
- .NET SDK `10.0` (preview/RC)

## Run locally
```bash
dotnet restore
dotnet run
```

Default local URLs from launch settings:
- `http://localhost:5132`
- `https://localhost:7148`

Swagger UI:
- `http://localhost:5132/swagger`
- `https://localhost:7148/swagger`

## Database
Configured connection string:

```json
"SqliteConnection": "Data Source= Database/MyPrototypeDb.db"
```

On startup, the app seeds:
- 1 product (`Withat Brush Cleaner`)
- 1 customer (`John`)

Only seeded when the corresponding table is empty.

## API overview
Base route groups:
- `/product`
- `/customer`
- `/order`

Enum JSON behavior is configured to use string values (not integers) when enums are used in request/response models.

## Product endpoints

### `GET /product/`
Returns all products.

### `GET /product/{id}`
Returns a product by id.

### `POST /product/`
Creates a product.

Request body:
```json
{
  "productName": "Foam Cleanser",
  "boughtPrice": 5.5,
  "sellingPrice": 9.99,
  "productGroupType": "Cleanser",
  "productDescription": "120ml",
  "status": "Active"
}
```

### `PUT /product/{id}`
Updates a product by id with the same body as `POST`.

### `DELETE /product/{id}`
Deletes a product by id.

## Customer endpoints

### `GET /customer/`
Returns all customers.

### `GET /customer/{id}`
Returns a customer by id.

### `POST /customer/`
Creates a customer.

Request body:
```json
{
  "name": "Jane Doe",
  "phoneNumber": "012 345 678",
  "email": "jane@example.com",
  "address": "House 2",
  "contactPreference": "Email"
}
```

### `PUT /customer/{id}`
Updates a customer by id with the same body as `POST`.

### `DELETE /customer/{id}`
Deletes a customer by id.

## Order endpoints

### `GET /order/`
Returns all orders.

### `GET /order/{orderId}`
Returns a single order by order id.

### `GET /order/customerid/{id}`
Returns orders by customer id.

Note: route parameter is named `{id}` in the route but `customerId` in handler argument. If this endpoint behaves unexpectedly at runtime, align both names.

### `POST /order/`
Creates an order.

Request body:
```json
{
  "customerID": 1,
  "paymentType": "CreditCard",
  "item": [
    {
      "productID": 1,
      "orderedQuantity": 2
    }
  ]
}
```

`paymentType` allowed values:
- `NotSpecified`
- `CreditCard`
- `Cash`

### `PUT /order/{orderId}?orderStatus=Completed`
Updates an order status via query string enum value.

`orderStatus` allowed values:
- `NotSpecified`
- `Pending`
- `InProgress`
- `Completed`
- `Deleted`

## EF Core migration commands
```bash
dotnet ef migrations add <MigrationName>
dotnet ef database update
```

If `dotnet ef` is unavailable:
```bash
dotnet tool install --global dotnet-ef
```
