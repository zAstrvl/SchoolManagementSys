using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSys.Data;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private readonly SchoolContext _context;
        public ParentsController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Parent>>> GetParents()
        {
            var parents = await _context.Parents.ToListAsync();
            return Ok(parents);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Parent>> GetParentById(int id)
        {
            var parent = await _context.Parents.FindAsync(id);
            if (parent == null)
                return NotFound();
            return Ok(parent);
        }
        [HttpPost]
        public async Task<ActionResult<Parent>> AddParent(Parent newParent)
        {
            if (newParent == null || string.IsNullOrWhiteSpace(newParent.Name) || string.IsNullOrWhiteSpace(newParent.Surname))
                return BadRequest("Invalid teacher data.");
            _context.Parents.Add(newParent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetParentById), new { id = newParent.Id }, newParent);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateParent(int id, Parent updatedParent)
        {
            var parent = await _context.Parents.FirstOrDefaultAsync(s => s.Id == id);
            if (parent == null)
                return NotFound();

            parent.Name = updatedParent.Name;
            parent.Surname = updatedParent.Surname;
            parent.DateOfBirth = updatedParent.DateOfBirth;
            parent.Email = updatedParent.Email;
            parent.PhoneNumber = updatedParent.PhoneNumber;
            parent.Address = updatedParent.Address;

            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteParent(int id)
        {
            var parent = await _context.Parents.FirstOrDefaultAsync(s => s.Id == id);
            if (parent == null)
                return NotFound();

            _context.Parents.Remove(parent);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
