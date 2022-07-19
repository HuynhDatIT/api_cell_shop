using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using CellShop_Api.Enum;
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
        public void SendEmailInvoice(EmailRequest emailRequest)
        {

            var emailMessage = CreateEmailMessageInvoice(emailRequest);
            Send(emailMessage);

        }
        public void SendEmailForgotPassword(string newPassword, string to, string name)
        {

            var emailMessage = CreateEmailMessageForgotPassword(newPassword, to, name);
            Send(emailMessage);

        }
        private MailMessage CreateEmailMessageInvoice(EmailRequest emailRequest)
        {
            var template = File.ReadAllText("TemplateEmail\\InvoiceEmail.html");
            var templatenew = template.Replace("[$$var(name)]", emailRequest.AccountName)
                                       .Replace("[$$var(status)]", ReplaceEnum(emailRequest.DeliveryStatus))
                                       .Replace("[$$var(addresse)]", emailRequest.DeliveryAddress)
                                       .Replace("[$$var(nameAddresse)]", emailRequest.DeliveryName)
                                       .Replace("[$$var(phone)]", emailRequest.DeliveryPhone)
                                       .Replace("[$$var(date)]", emailRequest.DateInvoice.ToString("dd/MM/yyyy"))
                                       .Replace("[$$var(total)]", emailRequest.Total.ToString("#.###"));
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailConfig.From);
            mailMessage.To.Add(new MailAddress(emailRequest.To));
            mailMessage.Subject = "CellShop";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = templatenew;

            return mailMessage;
        }
        private MailMessage CreateEmailMessageForgotPassword(string newPassword, string to, string name)
        {
            var template = File.ReadAllText("TemplateEmail\\ForgotPassword.html");
            var templatenew = template.Replace("[$$var(name)]", name)
                                      .Replace("[$$var(password)]", newPassword);
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailConfig.From);
            mailMessage.To.Add(new MailAddress(to));
            mailMessage.Subject = "CellShop";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = templatenew;

            return mailMessage;
        }
        private string ReplaceEnum(DeliveryStatus deliveryStatus)
        {
            string status = "";
            switch (deliveryStatus)
            {
                case DeliveryStatus.Order:
                    status = "Bạn vừa đặt hàng thành công!";
                    break;
                case DeliveryStatus.Delivery:
                    status = "Bạn có đơn hàng đang được giao!";
                    break;
                case DeliveryStatus.Done:
                    status = "Giao hàng thành công!";
                    break;
                case DeliveryStatus.Cancel:
                    status = "Đơn của bạn đã hủy!";
                    break;
                default:
                    break;
            }
            return status;
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
