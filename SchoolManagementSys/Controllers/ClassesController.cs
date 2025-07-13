using SchoolManagementSys.Data;
using SchoolManagementSys.Models;
using SchoolManagementSys.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase

    {
        private readonly SchoolContext _context;

        public ClassesController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Class>>> GetClasses()
        {
            var classes = await _context.Classes
                .Include(c => c.Teacher)
                .Include(c => c.Students)
                .ToListAsync();

            var classDtos = classes.Select(c => new ClassCreateDto
            {
                Id = c.Id,
                Name = c.Name,
                TeacherId = c.TeacherId,
                StudentIds = c.Students.Select(s => s.Id).ToList()
            }).ToList();

            return Ok(classDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClassCreateDto>> GetClassById(int id)
        {
            var classEntity = await _context.Classes
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (classEntity == null)
                return NotFound();

            var dto = new ClassCreateDto
            {
                Id = classEntity.Id,
                Name = classEntity.Name,
                TeacherId = classEntity.TeacherId,
                StudentIds = classEntity.Students.Select(s => s.Id).ToList()
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> AddClass([FromBody] ClassCreateDto dto)
        {
            var teacher = await _context.Teachers.FindAsync(dto.TeacherId);

            if (teacher == null) 
                return BadRequest("Teacher not found.");

            var students = await _context.Students
                .Where(s => dto.StudentIds.Contains(s.Id))
                .ToListAsync();
            
            var newClass = new Class
            {
                Name = dto.Name,
                Teacher = teacher,
                Students = students
            };

            var classDto = new ClassCreateDto
            {
                Id = newClass.Id,
                Name = newClass.Name,
                TeacherId = newClass.TeacherId,
                StudentIds = newClass.Students.Select(s => s.Id).ToList()
            };

            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();
            return Ok(classDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClass(int id, ClassCreateDto updatedClass)
        {
            var classEntity = await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);

            if (classEntity == null)
                return NotFound();

            var classDto = new ClassCreateDto
            {
                Id = classEntity.Id,
                Name = classEntity.Name,
                TeacherId = classEntity.TeacherId,
                StudentIds = classEntity.Students.Select(s => s.Id).ToList()
            };

            updatedClass.StudentIds ??= new List<int>();

            classDto.Id = updatedClass.Id;
            classDto.Name = updatedClass.Name;
            classDto.TeacherId = updatedClass.TeacherId;
            classDto.StudentIds = updatedClass.StudentIds;

            classEntity.Name = updatedClass.Name;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass(int id)
        {
            var classEntity = await _context.Classes.FindAsync(id);

            if (classEntity == null)
                return NotFound();

            var students = _context.Students
                .Where(s => s.ClassId == id)
                .ToList();

            foreach (var student in students)
                student.ClassId = null;

            _context.Classes.Remove(classEntity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
