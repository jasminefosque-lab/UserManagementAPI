using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static readonly ConcurrentBag<User> _users = new();
    private static int _nextId = 1;
    private static readonly object _lockObject = new();

    // GET: api/users
    [HttpGet]
    public ActionResult<IEnumerable<User>> GetUsers()
    {
        return Ok(_users);
    }

    // GET: api/users/{id}
    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    // POST: api/users
    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User user)
    {
        lock (_lockObject)
        {
            user.Id = _nextId++;
        }
        _users.Add(user);
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // PUT: api/users/{id}
    // Note: The id from the route parameter is used; any Id value in the request body is ignored
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        user.Name = updatedUser.Name;
        user.Email = updatedUser.Email;

        return NoContent();
    }

    // DELETE: api/users/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var user = _users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        // Remove from ConcurrentBag by creating a new bag without the deleted user
        var updatedUsers = _users.Where(u => u.Id != id).ToList();
        while (_users.TryTake(out _)) { }
        foreach (var u in updatedUsers)
        {
            _users.Add(u);
        }

        return NoContent();
    }
}
