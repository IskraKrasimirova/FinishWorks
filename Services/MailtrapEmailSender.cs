using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace FinishWorks.Services
{
    public class MailtrapEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public MailtrapEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string htmlContent)
        {
            var host = _configuration["Mailtrap:Host"];
            var portString = _configuration["Mailtrap:Port"];

            if (!int.TryParse(portString, out var port))
            {
                port = 587; // default Mailtrap port
            }

            var user = _configuration["Mailtrap:User"];
            var pass = _configuration["Mailtrap:Pass"];

            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(user, pass),
                EnableSsl = true
            };

            var message = new MailMessage
            {
                From = new MailAddress("noreply@finishworks.local", "FinishWorks Dev"),
                Subject = subject,
                Body = htmlContent,
                IsBodyHtml = true
            };

            message.To.Add(to);

            await client.SendMailAsync(message);
        }
    }
}