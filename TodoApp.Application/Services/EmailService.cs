using System.Net;
using System.Net.Mail;
using TodoApp.Application.Interfaces;

namespace TodoApp.Application.Services
{
    public class EmailService : IEmailService
    {
        private SmtpClient _client;
        public EmailService()
        {
            _client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("projects084utilities@outlook.com", "Z86P6byCeYbbiWP"),
                UseDefaultCredentials = false
            };
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var message = new MailMessage(
                    from: "projects084utilities@outlook.com",
                    to: to,
                    subject: subject,
                    body: body
                );

            message.IsBodyHtml = true;

            await _client.SendMailAsync(message);
        }
    }
}
