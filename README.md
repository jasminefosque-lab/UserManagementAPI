# UserManagementAPI

A minimal API for managing users built with .NET 8. This project demonstrates a simple CRUD (Create, Read, Update, Delete) API using minimal APIs with in-memory data storage.

## Features

- **User Model**: Includes Id, FirstName, LastName, and Email properties
- **CRUD Operations**: Full create, read, update, and delete functionality
- **Swagger/OpenAPI**: Interactive API documentation and testing interface
- **In-Memory Storage**: Uses an in-memory list for storing users
- **Minimal APIs**: Built using .NET's minimal API approach for simplicity

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later

## Project Structure

```
UserManagementAPI/
├── Models/
│   └── User.cs              # User model with properties
├── Program.cs               # Main application file with API endpoints
├── UserManagementAPI.csproj # Project file
└── README.md                # This file
```

## Setup Instructions

1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   cd UserManagementAPI
   ```

2. **Restore dependencies**:
   ```bash
   dotnet restore
   ```

3. **Build the project**:
   ```bash
   dotnet build
   ```

## Running the Application

1. **Run the application**:
   ```bash
   dotnet run
   ```

2. **Access the API**:
   - The API will start on `https://localhost:5001` (or `http://localhost:5000`)
   - Swagger UI will be available at: `https://localhost:5001/swagger`

3. **Default Data**:
   The API starts with two sample users pre-loaded in memory.

## API Endpoints

### Get All Users
```http
GET /api/users
```
Returns a list of all users.

### Get User by ID
```http
GET /api/users/{id}
```
Returns a specific user by their ID.

### Create User
```http
POST /api/users
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Doe",
  "email": "john.doe@example.com"
}
```
Creates a new user. The ID is auto-generated.

### Update User
```http
PUT /api/users/{id}
Content-Type: application/json

{
  "firstName": "John",
  "lastName": "Smith",
  "email": "john.smith@example.com"
}
```
Updates an existing user.

### Delete User
```http
DELETE /api/users/{id}
```
Deletes a user by their ID.

## Using Swagger UI

1. Navigate to `https://localhost:5001/swagger` in your browser
2. You'll see an interactive interface with all available endpoints
3. Click on any endpoint to expand it
4. Click "Try it out" to test the endpoint
5. Fill in any required parameters and click "Execute"
6. View the response directly in the browser

## Example Usage with curl

```bash
# Get all users
curl -X GET https://localhost:5001/api/users -k

# Get user by ID
curl -X GET https://localhost:5001/api/users/1 -k

# Create a new user
curl -X POST https://localhost:5001/api/users \
  -H "Content-Type: application/json" \
  -d '{"firstName":"Alice","lastName":"Johnson","email":"alice.johnson@example.com"}' \
  -k

# Update a user
curl -X PUT https://localhost:5001/api/users/1 \
  -H "Content-Type: application/json" \
  -d '{"firstName":"John","lastName":"Updated","email":"john.updated@example.com"}' \
  -k

# Delete a user
curl -X DELETE https://localhost:5001/api/users/1 -k
```

## Development

To run the application in watch mode (auto-reload on file changes):
```bash
dotnet watch run
```

## Notes

- This project uses in-memory storage, so all data will be lost when the application stops
- For production use, consider implementing a persistent data storage solution (database)
- The API uses HTTPS by default in development mode

## Technologies Used

- .NET 8
- Minimal APIs
- Swashbuckle.AspNetCore (Swagger/OpenAPI)

## Middleware

This API includes several middleware components that enhance reliability, security, and observability:

### Error Handling
A global error-handling middleware captures unhandled exceptions and returns a consistent JSON error response. This ensures the API responds gracefully when unexpected errors occur.

### Authentication
A simple authentication middleware validates incoming requests using a static Bearer token.  
Clients must include the following header to access protected endpoints:

Authorization: Bearer mysecrettoken

Requests without a valid token receive a 401 Unauthorized response.

### Logging
A lightweight logging middleware records each request’s method, path, and response status code.  
This helps with debugging and provides visibility into API usage.

## Swagger Security

Swagger is configured with a Bearer token security definition.  
You can authenticate directly in Swagger by clicking the **Authorize** button and entering:

Bearer mysecrettoken

Once authorized, Swagger automatically includes the token in all requests made through the UI.


## License

This project is provided as-is for educational and demonstration purposes.
