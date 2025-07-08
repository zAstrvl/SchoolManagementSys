using Microsoft.AspNetCore.Mvc;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private static readonly List<Student> students = [];

        [HttpGet]
        public ActionResult<List<Student>> GetStudents()
        {
            return Ok(students);
        }
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if(student == null)
                return NotFound();
            return Ok(student);
        }
        [HttpPost]
        public ActionResult<Student> AddStudent(Student newStudent)
        {
            if (newStudent == null || string.IsNullOrWhiteSpace(newStudent.Name) || string.IsNullOrWhiteSpace(newStudent.Surname))
                return BadRequest("Invalid student data.");
            newStudent.Id = students.Max(s => s.Id) + 1;
            students.Add(newStudent);
            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.Id }, newStudent);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            student.Id = updatedStudent.Id;
            student.Name = updatedStudent.Name;
            student.Surname = updatedStudent.Surname;
            student.DateOfBirth = updatedStudent.DateOfBirth;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            students.Remove(student);
            return NoContent();
        }
    }
}
