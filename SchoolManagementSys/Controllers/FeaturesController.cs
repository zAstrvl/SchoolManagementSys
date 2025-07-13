using SchoolManagementSys.Models;
using SchoolManagementSys.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly SchoolContext _context;

        public FeaturesController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Features>>> GetFeatures()
        {
            var features = await _context.Features.ToListAsync();

            if (features == null || !features.Any())
            {
                return NotFound("No features found.");
            }

            return Ok(features);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature([FromBody] Features feature)
        {
            var features = await _context.Features.FirstOrDefaultAsync(f => f.Title == feature.Title);

            if (feature == null || string.IsNullOrEmpty(feature.Title))
            {
                return BadRequest("Invalid feature data.");
            }
            
            if (features != null)
                return BadRequest("Feature with this title already exists.");

            var newFeature = new Features
            {
                Title = feature.Title,
                Description = feature.Description,
                ImageUrl = feature.ImageUrl
            };

            _context.Features.Add(feature);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFeatures), new { id = feature.Id }, feature);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var feature = await _context.Features.FindAsync(id);

            if (feature == null)
            {
                return NotFound("Feature not found.");
            }

            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
