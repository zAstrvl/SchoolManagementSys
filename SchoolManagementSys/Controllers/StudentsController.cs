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
            {
                return NotFound();
            }
            return Ok(student);
        }
    }
}
