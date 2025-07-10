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
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var parent = await _context.Parents.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (parent != null && HashClass.VerifyPassword(parent.PasswordHash, loginDto.Password))
            {
                var token = JwtTokenHelper.GenerateToken(parent.Email!, _configuration["Jwt:Key"]);
                return Ok(new { token, userType = "Parent" });
            }

            var teacher = await _context.Teachers.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (teacher != null && HashClass.VerifyPassword(teacher.PasswordHash, loginDto.Password))
            {
                var token = JwtTokenHelper.GenerateToken(teacher.Email!, _configuration["Jwt:Key"]);
                return Ok(new { token, userType = "Teacher" });
            }

            var student = await _context.Students.FirstOrDefaultAsync(u => u.Email == loginDto.Email);
            if (student != null && HashClass.VerifyPassword(student.PasswordHash, loginDto.Password))
            {
                var token = JwtTokenHelper.GenerateToken(student.Email!, _configuration["Jwt:Key"]);
                return Ok(new { token, userType = "Student" });
            }

            return Unauthorized();
        }
    }
}
