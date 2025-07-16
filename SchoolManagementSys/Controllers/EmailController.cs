using Microsoft.AspNetCore.Mvc;
using SchoolManagementSys.Models;

namespace SchoolManagementSys.Controllers
{
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
            if (mailData == null || string.IsNullOrEmpty(mailData.EmailTo) || string.IsNullOrEmpty(mailData.EmailSubject) || string.IsNullOrEmpty(mailData.EmailBody))
            {
                return BadRequest("Invalid mail data.");
            }

            try
            {
                await _emailSender.SendEmailAsync(mailData.EmailTo, mailData.EmailSubject, mailData.EmailBody);
                return Ok("E-posta başarıyla gönderildi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"E-posta gönderimi sırasında hata oluştu: {ex.Message}");
            }
        }
    }
}
