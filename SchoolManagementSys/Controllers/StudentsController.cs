using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        static private List<Student> students = new List<Student>
        {
            new Student { 
                Id = 1, 
                Name = "Eren", 
                Surname = "Arslan", 
                DateOfBirth = new DateTime(2004, 5, 31) 
            },
            new Student {
                Id = 2,
                Name = "Miraç Can",
                Surname = "Yüksel",
                DateOfBirth = new DateTime(2000, 10, 24)
            },
            new Student {
                Id = 3,
                Name = "Kürşat",
                Surname = "Özel",
                DateOfBirth = new DateTime(1981, 6, 26)
            },
            new Student {
                Id = 4,
                Name = "Ömer Can",
                Surname = "Yiğit",
                DateOfBirth = new DateTime(1993, 4, 27)
            }
        };
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
