using cell_shop_api.ViewModels.Request;
using CellShop_Api.Models;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IEmailService
    {
        void SendEmailInvoice(EmailRequest emailRequest);
        void SendEmailForgotPassword(string newPassword, string to, string name);
    }
}
