using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSys.Data;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly SchoolContext _context;

        public HeroController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hero>>> GetHeroes()
        {
            // Fetch all heroes from the database
            var heroes = await _context.Heroes.ToListAsync();

            // Check if the heroes list is null or empty
            if (heroes == null || !heroes.Any())
            {
                return NotFound("No heroes found.");
            }

            return Ok(heroes);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateHero([FromBody] Hero hero)
        {
            // Validate the hero object
            var heroEntity = await _context.Heroes.FirstOrDefaultAsync(h => h.Title == hero.Title);

            // Check if the hero object is null or has invalid data
            if (heroEntity != null)
            {
                return BadRequest("Hero with this title already exists.");
            }

            // Adding a new hero
            var newHero = new Hero
            {
                Title = hero.Title,
                Description = hero.Description,
                ImageUrl = hero.ImageUrl
            };

            _context.Heroes.Add(newHero);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetHeroes), new { id = newHero.Id }, newHero);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateHero(int id, [FromBody] Hero hero)
        {
            // Validate the hero object
            var heroEntity = await _context.Heroes.FindAsync(id);

            // Check if the hero object is null or has invalid data
            if (heroEntity == null)
                return NotFound();

            // Update the hero properties
            heroEntity.Title = hero.Title;
            heroEntity.Description = hero.Description;
            heroEntity.ImageUrl = hero.ImageUrl;

            _context.Entry(heroEntity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            // Find the hero by id
            var heroEntity = await _context.Heroes.FindAsync(id);

            // Check if the hero exists
            if (heroEntity == null)
            {
                return NotFound();
            }

            // Remove the hero from the database
            _context.Heroes.Remove(heroEntity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
