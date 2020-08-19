using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace ECommerce_Application.Models.Services
{
    public class EmailSenderService : IEmailSender
    {
        private IConfiguration _configuration;

        public EmailSenderService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(_configuration["SENDGRID_API_KEY"]);

            SendGridMessage message = new SendGridMessage();

            message.SetFrom("admin@superpets.com", "Super Pets");
            message.AddTo(email);
            message.SetSubject(subject);
            message.AddContent(MimeType.Html, htmlMessage);
            await client.SendEmailAsync(message);
        }
    }
}
