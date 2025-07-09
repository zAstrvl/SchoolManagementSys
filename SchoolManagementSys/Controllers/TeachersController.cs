using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSys.Data;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly SchoolContext _context;
        public TeachersController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> GetTeachers()
        {
            var teachers = await _context.Teachers.ToListAsync();
            return Ok(teachers);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacherById(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return NotFound();
            return Ok(teacher);
        }
        [HttpPost]
        public async Task<ActionResult<Teacher>> AddTeacher(Teacher newTeacher)
        {
            if (newTeacher == null || string.IsNullOrWhiteSpace(newTeacher.Name) || string.IsNullOrWhiteSpace(newTeacher.Surname))
                return BadRequest("Invalid teacher data.");
            _context.Teachers.Add(newTeacher);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTeacherById), new { id = newTeacher.Id }, newTeacher);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, Teacher updatedTeacher)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Id == id);
            if (teacher == null)
                return NotFound();

            teacher.Name = updatedTeacher.Name;
            teacher.Surname = updatedTeacher.Surname;
            teacher.DateOfBirth = updatedTeacher.DateOfBirth;
            teacher.Subject = updatedTeacher.Subject;
            teacher.Email = updatedTeacher.Email;
            teacher.PhoneNumber = updatedTeacher.PhoneNumber;
            teacher.Graduated = updatedTeacher.Graduated;

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(s => s.Id == id);
            if (teacher == null)
                return NotFound();

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
