# UserManagementAPI

A simple ASP.NET Core Web API for managing users, built for the Coursera Back-End Development with .NET project.

## Features

- Full CRUD operations for user management
- RESTful API endpoints
- In-memory data storage with thread-safe implementation
- Built with .NET 10 and ASP.NET Core

## API Endpoints

### Get All Users
```
GET /api/users
```
Returns a list of all users.

### Get User by ID
```
GET /api/users/{id}
```
Returns a specific user by their ID.

### Create User
```
POST /api/users
Content-Type: application/json

{
  "name": "John Doe",
  "email": "john.doe@example.com"
}
```
Creates a new user and returns the created user with an assigned ID.

### Update User
```
PUT /api/users/{id}
Content-Type: application/json

{
  "name": "John Doe Updated",
  "email": "john.updated@example.com"
}
```
Updates an existing user. Returns 204 No Content on success, 404 if user not found.

### Delete User
```
DELETE /api/users/{id}
```
Deletes a user by ID. Returns 204 No Content on success, 404 if user not found.

## Running the API

1. Navigate to the project directory:
   ```bash
   cd UserManagementAPI
   ```

2. Build the project:
   ```bash
   dotnet build
   ```

3. Run the API:
   ```bash
   dotnet run
   ```

4. The API will be available at: `http://localhost:5234`

## Testing

You can test the API using:
- The included `UserManagementAPI.http` file (with Visual Studio Code REST Client extension)
- curl commands
- Postman or similar API testing tools

Example curl commands:
```bash
# Get all users
curl http://localhost:5234/api/users

# Create a user
curl -X POST http://localhost:5234/api/users \
  -H "Content-Type: application/json" \
  -d '{"name":"Alice","email":"alice@example.com"}'

# Get user by ID
curl http://localhost:5234/api/users/1

# Update a user
curl -X PUT http://localhost:5234/api/users/1 \
  -H "Content-Type: application/json" \
  -d '{"name":"Alice Updated","email":"alice.updated@example.com"}'

# Delete a user
curl -X DELETE http://localhost:5234/api/users/1
```

## Project Structure

```
UserManagementAPI/
├── Controllers/
│   └── UsersController.cs    # CRUD endpoints implementation
├── Models/
│   └── User.cs                # User data model
├── Program.cs                 # Application entry point
├── appsettings.json          # Configuration
└── UserManagementAPI.http    # HTTP test file
```

## Technology Stack

- .NET 10
- ASP.NET Core Web API
- OpenAPI/Swagger support

