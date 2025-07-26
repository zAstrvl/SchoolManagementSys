using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSys.Data;
using SchoolManagementSys.Models;

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
        [AllowAnonymous]
        public async Task<ActionResult<AboutUs>> GetAboutUs()
        {
            var aboutUs = await _context.AboutUs.ToListAsync();

            // Check if the About Us information exists
            if (aboutUs == null)
            {
                return NotFound("About Us information not found.");
            }

            return Ok(aboutUs);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<AboutUs>> CreateAboutUs([FromBody] AboutUs aboutUs)
        {
            // Check if the aboutUs object is null or has invalid data
            if (aboutUs == null)
            {
                return BadRequest("Invalid About Us data.");
            }

            // Adds data
            _context.AboutUs.Add(aboutUs);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAboutUs), new { id = aboutUs.Id }, aboutUs);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAboutUs(int id, [FromBody] AboutUs aboutUs)
        {
            if (aboutUs == null || string.IsNullOrEmpty(aboutUs.Title))
            {
                return BadRequest("Invalid About Us data.");
            }

            // Check if the About Us information exists
            var existingAboutUs = await _context.AboutUs.FindAsync(id);
            if (existingAboutUs == null)
            {
                return NotFound("About Us information not found.");
            }

            // Update the existing About Us information
            existingAboutUs.Title = aboutUs.Title;
            existingAboutUs.Description = aboutUs.Description;

            _context.AboutUs.Update(existingAboutUs);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAboutUs(int id)
        {
            var aboutUs = await _context.AboutUs.FindAsync(id);

            if (aboutUs == null)
            {
                return NotFound("About Us information not found.");
            }

            // Remove the About Us information
            _context.AboutUs.Remove(aboutUs);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
