using SchoolManagementSys.Data;
using SchoolManagementSys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var heroes = await _context.Heroes.ToListAsync();

            if (heroes == null || !heroes.Any())
            {
                return NotFound("No heroes found.");
            }

            return Ok(heroes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHero([FromBody] Hero hero)
        {
            var heroEntity = await _context.Heroes.FirstOrDefaultAsync(h => h.Title == hero.Title);

            if (heroEntity != null)
            {
                return BadRequest("Hero with this title already exists.");
            }

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHero(int id)
        {
            var heroEntity = await _context.Heroes.FindAsync(id);

            if (heroEntity == null)
            {
                return NotFound();
            }

            _context.Heroes.Remove(heroEntity);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
