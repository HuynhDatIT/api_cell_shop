using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using CellShop_Api.Models;
using Newtonsoft.Json;
using StackExchange.Profiling.Internal;
using System.Collections.Generic;
using System.IO;
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
        public void SendEmail(EmailRequest emailRequest)
        {
            try
            {
                var emailMessage = CreateEmailMessage(emailRequest);
                Send(emailMessage);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        private MailMessage CreateEmailMessage(EmailRequest emailRequest)
        {
            var template = File.ReadAllText("TemplateEmail\\base-email.html");
            var templatenew = template.Replace("[$$var(name)]", emailRequest.AccountName)
                                       .Replace("[$$var(status)]", emailRequest.DeliveryStatus.ToString())
                                       .Replace("[$$var(addresse)]", emailRequest.DeliveryAddress)
                                       .Replace("[$$var(nameAddresse)]", emailRequest.DeliveryName)
                                       .Replace("[$$var(phone)]", emailRequest.DeliveryPhone)
                                       .Replace("[$$var(date)]", emailRequest.DateInvoice)
                                       .Replace("[$$var(total)]", emailRequest.Total.ToString());
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailConfig.From);
            mailMessage.To.Add(new MailAddress(emailRequest.To));
            mailMessage.Subject = "CellShop";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = templatenew;

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
