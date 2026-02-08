using UserManagementAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

// In-memory user storage
var users = new List<User>
{
    new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
    new User { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" }
};

// GET all users
app.MapGet("/api/users", () =>
{
    return Results.Ok(users);
})
.WithName("GetAllUsers");

// GET user by id
app.MapGet("/api/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    return user is not null ? Results.Ok(user) : Results.NotFound();
})
.WithName("GetUserById");

// POST create new user
app.MapPost("/api/users", (User user) =>
{
    // Generate new ID
    user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;
    users.Add(user);
    return Results.Created($"/api/users/{user.Id}", user);
})
.WithName("CreateUser");

// PUT update user
app.MapPut("/api/users/{id}", (int id, User updatedUser) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user is null)
    {
        return Results.NotFound();
    }

    user.FirstName = updatedUser.FirstName;
    user.LastName = updatedUser.LastName;
    user.Email = updatedUser.Email;

    return Results.Ok(user);
})
.WithName("UpdateUser");

// DELETE user
app.MapDelete("/api/users/{id}", (int id) =>
{
    var user = users.FirstOrDefault(u => u.Id == id);
    if (user is null)
    {
        return Results.NotFound();
    }

    users.Remove(user);
    return Results.NoContent();
})
.WithName("DeleteUser");

app.Run();
