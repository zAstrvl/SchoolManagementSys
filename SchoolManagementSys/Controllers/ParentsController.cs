using Microsoft.AspNetCore.Mvc;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentsController : ControllerBase
    {
        private static readonly List<Parent> parents = [];

        [HttpGet]
        public ActionResult<List<Parent>> GetParents()
        {
            return Ok(parents);
        }

        [HttpGet("{id}")]
        public ActionResult<Parent> GetParentById(int id)
        {
            var parent = parents.FirstOrDefault(p => p.Id == id);
            if (parent == null)
                return NotFound();

            return Ok(parent);
        }

        [HttpPost]
        public ActionResult<Parent> AddParent(Parent newParent)
        {
            if (newParent == null || string.IsNullOrWhiteSpace(newParent.Name) || string.IsNullOrWhiteSpace(newParent.Surname))
                return BadRequest("Invalid parent data.");

            newParent.Id = parents.Any() ? parents.Max(p => p.Id) + 1 : 1;
            parents.Add(newParent);

            return CreatedAtAction(nameof(GetParentById), new { id = newParent.Id }, newParent);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateParent(int id, Parent updatedParent)
        {
            var parent = parents.FirstOrDefault(p => p.Id == id);
            if (parent == null)
                return NotFound();

            parent.Name = updatedParent.Name;
            parent.Surname = updatedParent.Surname;
            parent.DateOfBirth = updatedParent.DateOfBirth;
            parent.Email = updatedParent.Email;
            parent.PhoneNumber = updatedParent.PhoneNumber;
            parent.Address = updatedParent.Address;

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteParent(int id)
        {
            var parent = parents.FirstOrDefault(p => p.Id == id);
            if (parent == null)
                return NotFound();

            parents.Remove(parent);
            return NoContent();
        }
    }
}
