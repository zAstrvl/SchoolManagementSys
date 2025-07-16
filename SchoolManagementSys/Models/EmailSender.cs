using System.Net.Mail;
using System.Net;

namespace SchoolManagementSys.Models
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var mail = _configuration["EmailSettings:SenderEmail"];
            var password = _configuration["EmailSettings:Password"];
            var server = _configuration["EmailSettings:Server"];
            var smtpPort = int.TryParse(_configuration["EmailSettings:Port"], out var port) ? port : 587;

            using var client = new SmtpClient(server, smtpPort)
            {
                Credentials = new NetworkCredential(mail, password),
                EnableSsl = true
            };

            using var mailMessage = new MailMessage
            {
                From = new MailAddress(mail, "School Management"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            try
            {
                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            { 
            
                throw new InvalidOperationException("E-posta gönderimi başarısız oldu.", ex);
            }
        }
    }
}
