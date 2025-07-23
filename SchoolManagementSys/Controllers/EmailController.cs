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

        [HttpPost]
        public async Task<IActionResult> SendEmail([FromBody] MailData mailData)
        {
            if (mailData == null || string.IsNullOrEmpty(mailData.Email) || string.IsNullOrEmpty(mailData.Message) || string.IsNullOrEmpty(mailData.Name))
            {
                return BadRequest("Invalid mail data.");
            }

            try
            {
                await _emailSender.SendEmailAsync(mailData.Email, mailData.Name, mailData.Message);

                return Ok("E-posta başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"E-posta gönderimi sırasında hata oluştu: {ex.Message}");
            }
        }
    }
}
