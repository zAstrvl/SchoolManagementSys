using Microsoft.AspNetCore.Mvc;
using SchoolManagementSys.Data;
using SchoolManagementSys.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly SchoolContext _context;
        public ContactUsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactUs()
        {
            var contactUsList = await _context.ContactUs.ToListAsync();

            if (contactUsList == null)
            {
                return NotFound("No contact information found.");
            }

            return Ok(contactUsList);
        }

        [HttpPost]
        public async Task<IActionResult> PostContactUs(ContactUs contactUs)
        {
            if (contactUs == null || string.IsNullOrEmpty(contactUs.Name) || string.IsNullOrEmpty(contactUs.Email) || string.IsNullOrEmpty(contactUs.Message))
            {
                return BadRequest("Invalid contact information.");
            }

            _context.ContactUs.Add(contactUs);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContactUs), new { id = contactUs.Id }, contactUs);
        }
    }
}
