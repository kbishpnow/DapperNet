# DapperNet Example

This is a simple **Console Application** demonstrating how to use **Dapper** with **SQL Server** to fetch and manipulate data using a custom `DapperContext`. It shows how to retrieve data from a database using parameterized queries, as well as handle errors gracefully.

## Project Overview

This project demonstrates how to:

- Connect to a SQL Server database using a connection string stored in a `Config.json` file.
- Use **Dapper**, a lightweight Object-Relational Mapping (ORM) library for .NET, to execute SQL queries and map the results to C# models.
- Implement parameterized queries to prevent SQL injection attacks.
- Fetch data from the database based on a dynamic parameter (e.g., `siteId`).

## Requirements

- **.NET 6.0** or later.
- A **SQL Server** instance running with the appropriate database schema.
- A `Config.json` file that contains the connection string for your SQL Server.
