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
        public async Task SendEmailAsync(string email, string name, string message)
        {
            var senderMail = _configuration["EmailSettings:SenderEmail"];
            var receiverMail = _configuration["EmailSettings:ReceiverEmail"];
            var password = _configuration["EmailSettings:Password"];
            var server = _configuration["EmailSettings:Server"];
            var smtpPort = int.TryParse(_configuration["EmailSettings:Port"], out var port) ? port : 587;

            using var client = new SmtpClient(server, smtpPort)
            {
                Credentials = new NetworkCredential(senderMail, password),
                EnableSsl = true
            };

            using var mailMessage = new MailMessage
            {
                From = new MailAddress(senderMail, "School Management"),
                Subject = name,
                Body = $"Gönderen: {email}\n\nMesaj:\n{message}",
                IsBodyHtml = true
            };

            mailMessage.To.Add(receiverMail);

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
