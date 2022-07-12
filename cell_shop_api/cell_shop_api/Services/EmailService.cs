using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public void SendEmail(MessageEmail messageEmail)
        {
            var emailMessage = CreateEmailMessageAsync(messageEmail);
            Send(emailMessage);
        }
        private MimeMessage CreateEmailMessageAsync(MessageEmail messageEmail)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.UserName, _emailConfig.From));
            emailMessage.To.AddRange(messageEmail.To);
            emailMessage.Subject = messageEmail.Subject;
            emailMessage.Body = new TextPart
                (MimeKit.Text.TextFormat.Text)
            { Text = messageEmail.Content };

            return emailMessage;
        }

        private void Send(MimeMessage mailMessage)
        {
            SmtpClient client = new SmtpClient();
            client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
            client.Authenticate(_emailConfig.UserName, _emailConfig.Password);
        }
    }
}
