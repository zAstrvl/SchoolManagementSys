using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSys.Data;
using SchoolManagementSys.Dto;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly SchoolContext _context;
        public UsersController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            if (users == null || !users.Any())
            {
                return NotFound("No users found.");
            }

            var response = users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                UserType = u.UserType
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == user.Email);

            if (existingUser != null)
            {
                return BadRequest("A user with this email already exists.");
            }

            var hashedPassword = HashClass.HashPassword(user.Password);
            user.Password = hashedPassword;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var response = new UserDto
            {
                Name = user.Name,
                Email = user.Email,
                UserType = user.UserType
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (user == null || id != user.Id)
            {
                return BadRequest("Invalid user data.");
            }

            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.UserType = user.UserType;

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
