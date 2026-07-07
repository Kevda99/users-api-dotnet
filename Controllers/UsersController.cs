using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static readonly ConcurrentDictionary<int, User> _users = new();
        private static int _nextId = 0;

        private bool IsValidUser(User user, out string error)
        {
            if (string.IsNullOrWhiteSpace(user.FirstName)) { error = "First name is required."; return false; }
            if (string.IsNullOrWhiteSpace(user.LastName)) { error = "Last name is required."; return false; }
            if (string.IsNullOrWhiteSpace(user.Email) || !user.Email.Contains("@")) { error = "A valid email is required."; return false; }
            error = string.Empty;
            return true;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_users.Values);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            if (_users.TryGetValue(id, out var user))
            {
                return Ok(user);
            }
            return NotFound(new { message = $"User with ID {id} not found." });
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (!IsValidUser(user, out string error))
            {
                return BadRequest(new { error });
            }
            
            user.Id = System.Threading.Interlocked.Increment(ref _nextId);
            _users.TryAdd(user.Id, user);
            
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (!_users.ContainsKey(id))
                return NotFound(new { message = $"User with ID {id} not found." });
            
            if (!IsValidUser(updatedUser, out string error))
            {
                return BadRequest(new { error });
            }

            _users[id].FirstName = updatedUser.FirstName;
            _users[id].LastName = updatedUser.LastName;
            _users[id].Email = updatedUser.Email;
            _users[id].Department = updatedUser.Department;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (_users.TryRemove(id, out _))
            {
                return NoContent();
            }
            return NotFound(new { message = $"User with ID {id} not found." });
        }
    }
}
