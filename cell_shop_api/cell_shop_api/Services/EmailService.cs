using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using System.Net;
using System.Net.Mail;

namespace cell_shop_api.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailService(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }
        public void SendEmail()
        {
            var emailMessage = CreateEmailMessageAsync("1", "2");
            Send(emailMessage);
        }
        private MailMessage CreateEmailMessageAsync(string from, string to)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("cellshop.123quangtrung@gmail.com");
            mailMessage.To.Add(new MailAddress("huynhtandat080297@gmail.com"));
            mailMessage.Subject = "test";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = string.Format("<a style='color: red; '>Heloo <a>");

            return mailMessage;
        }
        private void Send(MailMessage mailMessage)
        {
            SmtpClient client = new SmtpClient();

            client.Host = _emailConfig.SmtpServer;
            //client.Username = "cellshop.123quangtrung@gmail.com";
            //client.Password = "Doantotnghiep123";

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = _emailConfig.Port;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;

            var credential = new NetworkCredential(
               _emailConfig.UserName, _emailConfig.Password);
            client.Credentials = credential;
            client.Send(mailMessage);
        }
    }
}
