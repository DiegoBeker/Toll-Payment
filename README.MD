# Toll Payment

## How to run

Clone this repository.

Run the commands

```bash
docker compose up -d
```

The application will be initialized with all services. PostreSQL, PG Admin web.

Also will be apllied the migrations.

Change ports on docker-compose.yml as you need.

The Application will be available on http://localhost:8080.

To test route and documentation access Swagger interface on http://localhost:8080/swagger/index.html

To access the database with Pg Admin Web access http://localhost:8081

Login with email: postgres@postgres.com password: postgres.

Connect a new server.

Give a name to the server.

On connection the host is postgres and also the user and password.

## Entities

### Ticket 

```typescript
{
	id: long; // ex: 1
	createdAt: DateTime; // ex: "2023-09-27T19:22:50.503Z"
	updatedAt: DateTime; // ex: "2023-09-27T19:22:50.503Z"
	plateNumber: string; // ex: "IH9JACX"
    value: int; // ex: 790
    paidValue: int; // ex: 790
    paymentStatus: PaymentStatus; // ex: 0 = PROCESSING, 1 = FAILED, 2 = SUCCESS
    paymentType: PaymentType; // ex: 0 = CASH, 1 = AUTOMATIC
}
```

## Endpoints 

### POST /tickets

- Create a ticket.

- Request Body:

```json
{
    "plate": "IH9JACX",
    "type": 0 // ex: 0 = CASH, 1 = AUTOMATIC
}
```
### PATCH /tickets/{status}/{ticketId}

EXAMPLES

- http://localhost:8080/tickets/SUCCESS/1

- http://localhost:8080/tickets/FAILED/1


## Answer to questions

### 1

I used the entity framework to map my model class into the database. The model class is located in Models/Ticket.cs

### 2

Database queries are also made with the ORM. They are located in Repositories/TicketRepository.cs

### 3 

The logic for calculating the value is in the files Services/TicketService.cs and Helpers/ValueCalculator.cs