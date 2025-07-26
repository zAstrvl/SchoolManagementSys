using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSys.Data;
using SchoolManagementSys.Models;

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
        [AllowAnonymous]
        public async Task<ActionResult<List<Features>>> GetFeatures()
        {
            var features = await _context.Features.ToListAsync();

            // Check if the features list is null or empty
            if (features == null || !features.Any())
            {
                return NotFound("No features found.");
            }

            return Ok(features);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateFeature([FromBody] Features feature)
        {
            var features = await _context.Features.FirstOrDefaultAsync(f => f.Title == feature.Title);

            if (feature == null || string.IsNullOrEmpty(feature.Title))
            {
                return BadRequest("Invalid feature data.");
            }

            // Check if feature exists
            if (features != null)
                return BadRequest("Feature with this title already exists.");

            var newFeature = new Features
            {
                Title = feature.Title,
                Description = feature.Description,
                ImageUrl = feature.ImageUrl
            };

            // Adds the feature
            _context.Features.Add(feature);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFeatures), new { id = feature.Id }, feature);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateFeature(int id, [FromBody] Features feature)
        {
            if (feature == null || string.IsNullOrEmpty(feature.Title))
            {
                return BadRequest("Invalid feature data.");
            }

            var featureEntity = await _context.Features.FindAsync(id);
            if (featureEntity == null)
            {
                return NotFound("Feature not found.");
            }

            // Update feature data
            featureEntity.Title = feature.Title;
            featureEntity.Description = feature.Description;
            featureEntity.ImageUrl = feature.ImageUrl;

            _context.Features.Update(featureEntity);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var feature = await _context.Features.FindAsync(id);

            if (feature == null)
            {
                return NotFound("Feature not found.");
            }

            // Remove feature data
            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
