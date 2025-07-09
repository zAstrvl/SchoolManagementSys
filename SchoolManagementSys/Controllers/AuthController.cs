using Microsoft.AspNetCore.Mvc;
using SchoolManagementSys.Data;
using SchoolManagementSys.Migrations;
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
        public IActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = _context.Parents.FirstOrDefault(p => p.Email == loginDto.Email && p.PasswordHash.ToString() == loginDto.Password);
            if (user == null)
                return Unauthorized();
            if (user.PasswordHash.ToString() != HashClass.HashPassword(loginDto.Password))
                return Unauthorized();
            var token = JwtTokenHelper.GenerateToken(user.Email, _configuration["Jwt:Key"]);
            return Ok(new { token });
        }
    }
}
