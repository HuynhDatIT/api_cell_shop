

using cell_shop_api.Services.InterfaceSevice;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendEmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public SendEmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }
        [HttpGet]
        public IActionResult SendEmail()
        {

            SmtpClient client = new SmtpClient();

            client.Host = "smtp.gmail.com";
            //client.Username = "cellshop.123quangtrung@gmail.com";
            //client.Password = "Doantotnghiep123";

            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;

            var credential = new NetworkCredential(
                "huynhdatit.focus@gmail.com", "Huynhtandat97");
            client.Credentials = credential;
          
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("huynhdatit.focus@gmail.com");
            mailMessage.To.Add( new MailAddress("huynhtandat080297@gmail.com"));
            mailMessage.Subject = "test";
            mailMessage.Body = "test";

           // mailMessage.IsBodyHtml = true;

            try
            {
                client.Send(mailMessage);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
        public static void CreateTestMessage3()
        {
            //// Create a new instance of MailMessage class
            //MailMessage message = new MailMessage();

            //// Set subject of the message, Html body, sender, and receiver information
            //message.Subject = "New message created by Aspose.Email for .NET";
            //message.HtmlBody = "<b>This line is in bold.</b> <br/> <br/>" + "<font color=blue>This line is in blue color</font>";
            //message.From = new MailAddress("cellshop.123quangtrung@gmail.com", "Sender Name", false);
            //message.To.Add(new MailAddress("huynhdatIT.focus@gmail.com", "Recipient 1", false));

            //// Specify encoding 
            //message.BodyEncoding = Encoding.ASCII;

            //// Save message in EML/EMLX/MSG/MHTML format
            //message.Save("EmailMessage.msg", SaveOptions.DefaultMsgUnicode);


        }
    }
}
