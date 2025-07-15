using SchoolManagementSys.Data;
using SchoolManagementSys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var testimonials = await _context.Testimonials.ToListAsync();

            if (testimonials == null || !testimonials.Any())
            {
                return NotFound("No testimonials found.");
            }

            return new JsonResult(testimonials);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Testimonials testimonial)
        {
            if (testimonial == null)
            {
                return BadRequest("Invalid testimonial data.");
            }

            var existingTestimonial = await _context.Testimonials
                .FirstOrDefaultAsync(t => t.Title == testimonial.Title);

            if (existingTestimonial != null)
            {
                return BadRequest("A testimonial with this title already exists.");
            }

            _context.Testimonials.Add(testimonial);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Index), new { id = testimonial.Id }, testimonial);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Testimonials testimonial)
        {
            if (testimonial == null)
            {
                return BadRequest("Invalid testimonial data.");
            }

            var existingTestimonial = await _context.Testimonials.FindAsync(id);
            if (existingTestimonial == null)
            {
                return NotFound("Testimonial not found.");
            }

            existingTestimonial.Title = testimonial.Title;
            existingTestimonial.Description = testimonial.Description;
            existingTestimonial.ImageUrl = testimonial.ImageUrl;

            _context.Testimonials.Update(existingTestimonial);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var testimonial = await _context.Testimonials.FindAsync(id);

            if (testimonial == null)
            {
                return NotFound("Testimonial not found.");
            }

            _context.Testimonials.Remove(testimonial);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
