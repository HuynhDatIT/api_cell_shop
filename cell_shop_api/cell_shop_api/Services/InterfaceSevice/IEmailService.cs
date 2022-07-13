using cell_shop_api.ViewModels.Request;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IEmailService
    {
        void SendEmail(MessageEmail messageEmail);
    }
}
