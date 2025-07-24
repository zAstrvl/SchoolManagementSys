using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Controllers
{
    [Route("api/mail")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        // Sends an email based on the provided mail data
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] MailData mailData)
        {
            // Empty or null check for mailData and its properties
            if (mailData == null || string.IsNullOrEmpty(mailData.Email) || string.IsNullOrEmpty(mailData.Message) || string.IsNullOrEmpty(mailData.Name))
            {
                return BadRequest("Invalid mail data.");
            }

            try
            {
                // Validate email format
                await _emailSender.SendEmailAsync(mailData.Email, mailData.Name, mailData.Message);

                return Ok("E-posta başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                // Log the exception (logging mechanism not shown here)
                return StatusCode(500, $"E-posta gönderimi sırasında hata oluştu: {ex.Message}");
            }
        }
    }
}
