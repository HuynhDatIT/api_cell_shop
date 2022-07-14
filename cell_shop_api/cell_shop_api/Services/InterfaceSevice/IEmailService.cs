using cell_shop_api.ViewModels.Request;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IEmailService
    {
        void SendEmail(string to, string addresse, string name, string phone, double total, string status);
    }
}
