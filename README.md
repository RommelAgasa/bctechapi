# BCTECHAPI

A RESTful API built with ASP.NET Core 10.0 for managing employee data using SQL Server.

## Prerequisites

- .NET 10.0 SDK or later
- SQL Server (with SQL Express or higher)
- Visual Studio Code or Visual Studio

## Project Setup

### 1. Clone/Open the Project

```bash
cd bc-tech-assessment/bctechapi
```

### 2. Install Dependencies

The required NuGet packages have been added:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

These are already configured in the `.csproj` file.

### 3. Database Configuration

Update the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "BCTECHAPI": "Server=LAPTOP-6LEU0GNE\\SQLEXPRESS;Database=bctech;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

Replace the server name with your SQL Server instance name if different.

### 4. Create Database Migrations

```bash
dotnet ef migrations add AddEmployeeTable --project ./bctechapi.csproj --output-dir Infrastructure/Migrations
```

### 5. Apply Migrations to Database

```bash
dotnet ef database update
```

## Running the Application

Start the API server:

```bash
dotnet run
```

The application will start on:
- **HTTP**: `http://localhost:5128`
- **HTTPS**: `https://localhost:7088`

## API Endpoints

All endpoints are prefixed with `/api/employee`

### Get All Employees
```
GET /api/employee
```
Returns a list of all employees.

### Get Employee by ID
```
GET /api/employee/{id}
```
Returns a single employee by ID. Returns 404 if not found.

**Example:**
```
GET /api/employee/1
```

### Create Employee
```
POST /api/employee
```
Creates a new employee. Request body should contain employee data.

**Example Request Body:**
```json
{
  "firstName": "John",
  "lastName": "Doe",
  "position": "Software Engineer",
  "salary": 75000,
  "hireDate": "2024-01-15"
}
```

### Update Employee
```
PUT /api/employee/{id}
```
Updates an existing employee. The ID in the URL must match the employee ID in the request body.

**Example Request Body:**
```json
{
  "id": 1,
  "firstName": "Jane",
  "lastName": "Doe",
  "position": "Senior Developer",
  "salary": 85000,
  "hireDate": "2023-06-20"
}
```

### Delete Employee
```
DELETE /api/employee/{id}
```
Deletes an employee by ID. Returns 204 No Content on success.

**Example:**
```
DELETE /api/employee/1
```

## Project Structure

```
BCTECHAPI/
├── Controllers/
│   └── EmployeeController.cs
├── Core/
│   ├── Interfaces/
│   │   └── IEmployeeService.cs
│   └── Models/
│       └── Employee.cs
├── Infrastructure/
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Migrations/
│   ├── Repositories/
│   │   └── EmployeeRepository.cs
│   └── Services/
│       └── EmployeeService.cs
├── ServicesExtension/
│   └── ServiceRegistration.cs
├── Program.cs
├── appsettings.json
└── bctechapi.csproj
```

## Employee Model

The Employee model represents an employee in the system with the following properties:

| Property | Type | Description |
|----------|------|-------------|
| Id | int | Unique identifier (auto-generated) |
| FirstName | string | Employee's first name |
| LastName | string | Employee's last name |
| Position | string | Job position/title |
| Salary | decimal | Annual salary |
| HireDate | DateTime | Date employee was hired (defaults to current date) |

All string properties are nullable.

- **Controllers**: Handle HTTP requests and responses
- **Services**: Contain business logic
- **Repositories**: Handle data access and database operations
- **Models**: Define data structures
- **DbContext**: Entity Framework Core context for database management
- **ServiceRegistration**: Dependency injection configuration

## Technologies Used

- **ASP.NET Core 10.0**: Web framework
- **Entity Framework Core 10.0**: ORM for database access
- **SQL Server**: Database
- **C# 13**: Programming language

## Configuration Files

### appsettings.json
Contains application settings including database connection string and logging configuration.

### launchSettings.json
Defines launch profiles for HTTP and HTTPS endpoints.

### bctechapi.csproj
Project file with target framework and NuGet package references.

## Troubleshooting

### Migration Issues
If you encounter migration errors, try:
```bash
dotnet ef migrations remove
dotnet ef migrations add AddEmployeeTable --project ./bctechapi.csproj --output-dir Infrastructure/Migrations
dotnet ef database update
```

### Connection String Issues
Verify your SQL Server instance name and that the database exists. Update `appsettings.json` accordingly.

### Port Already in Use
If the default ports are in use, modify the `applicationUrl` in `launchSettings.json`.

## License

This project is for educational purposes.

## Support

For issues or questions, refer to the official documentation:
- [ASP.NET Core Docs](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core Docs](https://docs.microsoft.com/ef/core)
