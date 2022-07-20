using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface ICartService 
    {
        Task<IEnumerable<GetCart>> GetCartsAsync();
        Task<bool> AddAsync(CreateCart createCart);
        Task<bool> UpdateAsync(UpdateCart updateCart);
        Task<bool> DeleteAsync(int cartid);
        Task<bool> DeleteCartRangeAsync(int accountId);
    }
}
