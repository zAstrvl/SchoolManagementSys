using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSys.Data;
using SchoolManagementSys.Dto;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SchoolContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(SchoolContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            // Check if the loginDto is null or contains empty fields
            if (user != null && HashClass.VerifyPassword(user.Password, loginDto.Password))
            {
                var token = JwtTokenHelper.GenerateToken(user.Email!, user.UserType.ToString()!, _configuration["Jwt:Key"]);
                return Ok(new { token, userType = user.UserType.ToString() });
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            // Check if the registerDto is null or contains empty fields
            var user = new RegisterDto
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = registerDto.Password,
                ConfirmPassword = registerDto.ConfirmPassword,
                Agreed = registerDto.Agreed,
                UserType = registerDto.UserType
            };

            if (registerDto.Name == null || registerDto.Email == null) {
                return BadRequest("Name and Email are required.");
            }

            // Checkout the password and confirmation password
            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                return BadRequest("Passwords do not match.");
            }

            // Check if the user has agreed to the terms and conditions
            if (!registerDto.Agreed)
            {
                return BadRequest("You must agree to the terms and conditions.");
            }

            // Check if the email already exists in the database
            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
            {
                return BadRequest("Email already exists.");
            }

            // Create a new user and save it to the database
            await _context.Users.AddAsync(new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                Password = HashClass.HashPassword(registerDto.Password),
                UserType = registerDto.UserType
            });

            await _context.SaveChangesAsync();
            return Ok(new { user });
        }
    }
}
