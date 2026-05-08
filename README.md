# StockFlowMonitor
# StockFlowMonitor

StockFlowMonitor is a simple inventory management web application built with F# and ASP.NET Core Minimal API.

The purpose of the project is to demonstrate basic stock management operations, functional programming concepts in F#, and simple web application development without using a database.

---

# Features

## Product Management
- Add new products
- Define minimum stock level
- Search products by name

## Stock Management
- Receive stock
- Issue stock
- Prevent issuing more stock than available

## Dashboard
- Display current stock values
- Low stock detection
- Product statistics

## Stock Movements
- Track incoming and outgoing movements
- View movement history

---

# Technologies Used

- F#
- ASP.NET Core Minimal API
- HTML
- CSS
- Git & GitHub

---

# Functional Programming Concepts

The project uses several F# functional programming concepts:

- Immutable data handling
- List processing with `map`, `filter`, and `sumBy`
- Pattern matching
- Function composition
- Modules
- Record types

---

# Project Structure

- `Program.fs` → Web routes and application logic
- `Storage.fs` → In-memory data storage
- `StockLogic.fs` → Business logic
- `Domain.fs` → Domain models
- `HtmlTemplates.fs` → Shared HTML layout

---

# Running the Project

1. Clone the repository

```bash
git clone https://github.com/YOUR_USERNAME/StockFlowMonitor.git
```

2. Open the solution in Visual Studio

3. Run the application

4. Open:

```text
https://localhost:7053
```

---

# Current Limitations

- Data is stored only in memory
- No database integration yet
- No authentication system
- No edit/delete functionality yet

---

# Future Improvements

- Database support
- Product editing
- Product deletion
- User authentication
- Charts and reports
- REST API improvements

---

# Author

Developed as a university F# project.
