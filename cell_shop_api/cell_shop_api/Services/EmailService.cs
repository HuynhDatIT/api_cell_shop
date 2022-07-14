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
        public void SendEmail(string to, string addresse, string name, string phone, double total, string status)
        {
            var emailMessage = CreateEmailMessageAsync(to, addresse, name, phone, total, status);
            Send(emailMessage);
        }
        private MailMessage CreateEmailMessageAsync(string to, string addresse, string name, string phone, double total, string status)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailConfig.From);
            mailMessage.To.Add(new MailAddress(to));
            mailMessage.Subject = "CellShop";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = Body(addresse, name, phone, total, status);

            return mailMessage;
        }
        public string Body(string addresse, string name, string phone, double total, string status)
        {
            string h1 = "<h1>Cell shop</h1> <br/>";
            string h2 = "<h2>Thông tin đơn hàng<h2> <br/>";
            string addressehtml = "<b>Địa chỉ:<b/>" + addresse + "<br/>";
            string namehtml = "<b>Người nhận:<b/>" + name + "<br/>";
            string phonehtml = "<b>Số điện thoại:<b/>" + phone + "<br/>";
            string totalhtml = "<b>Tổng tiền: <b/>" + total + "VNĐ <br/>";
            string statushtml = "<b>Trạng thái: <b/>" + status + "<br/>";
            string end = "<b>Cảm ơn quý khách<b/>";
            return h1 + h2 + addresse + namehtml + phonehtml + totalhtml + statushtml + end;
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
