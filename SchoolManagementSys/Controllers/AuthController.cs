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

            if (user != null && HashClass.VerifyPassword(user.PasswordHash, loginDto.Password))
            {
                var token = JwtTokenHelper.GenerateToken(user.Email!, user.UserType.ToString()!, _configuration["Jwt:Key"]);
                return Ok(new { token, userType = user.UserType.ToString() });
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
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

            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                return BadRequest("Passwords do not match.");
            }

            if (!registerDto.Agreed)
            {
                return BadRequest("You must agree to the terms and conditions.");
            }

            if (await _context.Users.AnyAsync(u => u.Email == registerDto.Email))
            {
                return BadRequest("Email already exists.");
            }

            await _context.Users.AddAsync(new User
            {
                Name = registerDto.Name,
                Email = registerDto.Email,
                PasswordHash = HashClass.HashPassword(registerDto.Password),
                UserType = registerDto.UserType
            });

            await _context.SaveChangesAsync();
            return Ok(new { user });
        }
    }
}
