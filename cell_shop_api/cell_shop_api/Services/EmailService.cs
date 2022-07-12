using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
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

        public Task SendEmailAsync(MessageEmail messageEmail)
        {
            throw new System.NotImplementedException();
        }

        //public void SendEmailAsync(MessageEmail messageEmail)
        //{
        //    var emailMessage = CreateEmailMessageAsync(messageEmail);
        //    Send(emailMessage);
        //}
        //private MimeMessage CreateEmailMessageAsync(MessageEmail messageEmail)
        //{
        //    var emailMessage = new MimeMessage();
        //    emailMessage.From.Add(new MailboxAddress("abc",_emailConfig.From));
        //    emailMessage.To.AddRange(messageEmail.To);
        //    emailMessage.Subject = messageEmail.Subject;
        //    emailMessage.Body = new TextPart
        //        (MimeKit.Text.TextFormat.Text) { Text = messageEmail.Content };

        //    return emailMessage;
        //}

        //private void Send(MimeMessage mailMessage)
        //{
        //    SmtpClient client = new SmtpClient();
        //    client.Connect("smtp_address_here", port_here, true);
        //    client.Authenticate("user_name_here", "pwd_here");
        //}
    }
}
