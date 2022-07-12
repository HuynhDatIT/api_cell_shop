using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IEmailService
    {
        Task SendEmailAsync(MessageEmail messageEmail);
    }
}
