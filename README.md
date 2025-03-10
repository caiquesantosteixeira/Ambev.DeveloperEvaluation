# Developer Evaluation Project

`READ CAREFULLY`

## Instructions
**The test below will have up to 3 calendar days to be delivered from the date of receipt of this manual.**

- The code must be versioned in a public Github repository and a link must be sent for evaluation once completed
- Upload this template to your repository and start working from it
- Read the instructions carefully and make sure all requirements are being addressed
- The repository must provide instructions on how to configure, execute and test the project
- Documentation and overall organization will also be taken into consideration

## Use Case
**You are a developer on the DeveloperStore team. Now we need to implement the API prototypes.**

As we work with `DDD`, to reference entities from other domains, we use the `External Identities` pattern with denormalization of entity descriptions.

Therefore, you will write an API (complete CRUD) that handles sales records. The API needs to be able to inform:

* Sale number
* Date when the sale was made
* Customer
* Total sale amount
* Branch where the sale was made
* Products
* Quantities
* Unit prices
* Discounts
* Total amount for each item
* Cancelled/Not Cancelled

It's not mandatory, but it would be a differential to build code for publishing events of:
* SaleCreated
* SaleModified
* SaleCancelled
* ItemCancelled

If you write the code, **it's not required** to actually publish to any Message Broker. You can log a message in the application log or however you find most convenient.

### Business Rules

* Purchases above 4 identical items have a 10% discount
* Purchases between 10 and 20 identical items have a 20% discount
* It's not possible to sell above 20 identical items
* Purchases below 4 items cannot have a discount

These business rules define quantity-based discounting tiers and limitations:

1. Discount Tiers:
   - 4+ items: 10% discount
   - 10-20 items: 20% discount

2. Restrictions:
   - Maximum limit: 20 items per product
   - No discounts allowed for quantities below 4 items

## Overview
To generate the project database, you need to run the migration commands
Add-Migration nameMigration -Project Ambev.DeveloperEvaluation.ORM
and then
Update-Database 
and also have PostgreSQL installed.

About the tables:
In this project, the user, after being created and logged in, will be able to create a Store followed by its branch and then register a customer.
Then he can register products and sales, after which he will be able to assign items to this sale.
After that, with a simple update in the purchase, he can cancel a purchase or not, as well as an update in the purchase items can cancel them.
See [Overview](/.doc/overview.md)

## Tech Stack
in this project the following were used:
.net core;
repository pattern;
entity framework;
mediator with IoC;
Postgres Sql;
DDD;

See [Tech Stack](/.doc/tech-stack.md)

## Frameworks
- .Net Core;
- Entity

See [Frameworks](/.doc/frameworks.md)

<!-- 
## API Structure
This section includes links to the detailed documentation for the different API resources:
- [API General](./docs/general-api.md)
- [Products API](/.doc/products-api.md)
- [Carts API](/.doc/carts-api.md)
- [Users API](/.doc/users-api.md)
- [Auth API](/.doc/auth-api.md)
-->

## Project Structure
- we have a repository layer for handling the database;
- a domain with the domain entities and stories;
- an application layer for each use case called by the API

See [Project Structure](/.doc/project-structure.md)
