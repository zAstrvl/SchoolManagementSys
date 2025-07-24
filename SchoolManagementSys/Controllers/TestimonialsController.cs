using SchoolManagementSys.Data;
using SchoolManagementSys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly SchoolContext _context;
        public TestimonialsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Fetch all testimonials from the database
            var testimonials = await _context.Testimonials.ToListAsync();

            if (testimonials == null || !testimonials.Any())
            {
                return NotFound("No testimonials found.");
            }

            return new JsonResult(testimonials);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([FromBody] Testimonials testimonial)
        {
            // Validate the testimonial object
            if (testimonial == null)
            {
                return BadRequest("Invalid testimonial data.");
            }

            // Check if a testimonial with the same title already exists
            var existingTestimonial = await _context.Testimonials
                .FirstOrDefaultAsync(t => t.Title == testimonial.Title);

            if (existingTestimonial != null)
            {
                return BadRequest("A testimonial with this title already exists.");
            }

            // Create a new testimonial
            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Index), new { id = testimonial.Id }, testimonial);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id, [FromBody] Testimonials testimonial)
        {
            if (testimonial == null)
            {
                return BadRequest("Invalid testimonial data.");
            }

            // Check if the testimonial exists
            var existingTestimonial = await _context.Testimonials.FindAsync(id);
            if (existingTestimonial == null)
            {
                return NotFound("Testimonial not found.");
            }

            // Update the testimonial properties
            existingTestimonial.Title = testimonial.Title;
            existingTestimonial.Description = testimonial.Description;
            existingTestimonial.ImageUrl = testimonial.ImageUrl;

            _context.Testimonials.Update(existingTestimonial);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            // Check if the testimonial exists
            var testimonial = await _context.Testimonials.FindAsync(id);

            if (testimonial == null)
            {
                return NotFound("Testimonial not found.");
            }

            // Remove the testimonial from the database
            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
