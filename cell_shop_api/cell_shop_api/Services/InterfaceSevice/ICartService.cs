using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface ICartService
    {
        Task<IEnumerable<GetCart>> GetCarts(int accountid);
        string Add(CreateCart createCart);
    }
}
