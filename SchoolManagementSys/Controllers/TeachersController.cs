using Microsoft.AspNetCore.Mvc;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private static readonly List<Teacher> teachers = [];

        [HttpGet]
        public ActionResult<List<Student>> GetTeacher()
        {
            return Ok(teachers);
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetTeacherById(int id)
        {
            var teacher = teachers.FirstOrDefault(s => s.Id == id);
            if (teacher == null)
                return NotFound();
            return Ok(teacher);
        }
        [HttpPost]
        public ActionResult<Student> AddTeacher(Teacher newTeacher)
        {
            if (newTeacher == null || string.IsNullOrWhiteSpace(newTeacher.Name) || string.IsNullOrWhiteSpace(newTeacher.Surname))
                return BadRequest("Invalid student data.");
            newTeacher.Id = teachers.Max(s => s.Id) + 1;
            teachers.Add(newTeacher);
            return CreatedAtAction(nameof(GetTeacherById), new { id = newTeacher.Id }, newTeacher);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, Teacher updatedTeacher)
        {
            var teacher = teachers.FirstOrDefault(s => s.Id == id);
            if (teacher == null)
                return NotFound();

            teacher.Id = updatedTeacher.Id;
            teacher.Name = updatedTeacher.Name;
            teacher.Surname = updatedTeacher.Surname;
            teacher.DateOfBirth = updatedTeacher.DateOfBirth;
            teacher.Subject = updatedTeacher.Subject;
            teacher.Email = updatedTeacher.Email;
            teacher.PhoneNumber = updatedTeacher.PhoneNumber;
            teacher.Graduated = updatedTeacher.Graduated;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            var teacher = teachers.FirstOrDefault(s => s.Id == id);
            if (teacher == null)
                return NotFound();

            teachers.Remove(teacher);
            return NoContent();
        }
    }
}
