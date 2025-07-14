using SchoolManagementSys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSys.Data;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly SchoolContext _context;

        public AboutUsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<AboutUs>> GetAboutUs()
        {
            var aboutUs = await _context.AboutUs.ToListAsync();

            if (aboutUs == null)
            {
                return NotFound("About Us information not found.");
            }

            return Ok(aboutUs);
        }

        [HttpPost]
        public async Task<ActionResult<AboutUs>> CreateAboutUs([FromBody] AboutUs aboutUs)
        {
            if (aboutUs == null)
            {
                return BadRequest("Invalid About Us data.");
            }

            _context.AboutUs.Add(aboutUs);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAboutUs), new { id = aboutUs.Id }, aboutUs);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAboutUs(int id)
        {
            var aboutUs = await _context.AboutUs.FindAsync(id);

            if (aboutUs == null)
            {
                return NotFound("About Us information not found.");
            }

            _context.AboutUs.Remove(aboutUs);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
