
using Aspose.Email;
using Aspose.Email.Clients;
using Aspose.Email.Clients.Smtp;
using cell_shop_api.Services.InterfaceSevice;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
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

            MailMessage msg = MailMessage.Load("EmailMessage.msg");

            SmtpClient client = new SmtpClient();

            client.Host = "mail.server.com";
            client.Username = "cellshop.123quangtrung@gmail.com";
            client.Password = "Doantotnghiep123";
            client.Port = 587;
            client.SecurityOptions = SecurityOptions.SSLExplicit;
            try
            {
                client.Send(msg);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        public static void CreateTestMessage3()
        {
            // Create a new instance of MailMessage class
            MailMessage message = new MailMessage();

            // Set subject of the message, Html body, sender, and receiver information
            message.Subject = "New message created by Aspose.Email for .NET";
            message.HtmlBody = "<b>This line is in bold.</b> <br/> <br/>" + "<font color=blue>This line is in blue color</font>";
            message.From = new MailAddress("cellshop.123quangtrung@gmail.com", "Sender Name", false);
            message.To.Add(new MailAddress("huynhdatIT.focus@gmail.com", "Recipient 1", false));

            // Specify encoding 
            message.BodyEncoding = Encoding.ASCII;

            // Save message in EML/EMLX/MSG/MHTML format
            message.Save("EmailMessage.msg", SaveOptions.DefaultMsgUnicode);


        }
    }
}
