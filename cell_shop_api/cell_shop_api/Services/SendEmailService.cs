using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailSettings _mailSettings;

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task<bool> SendEmailAsync(MailRequest mailRequest)
        {
            return true;
        }
    }
}
