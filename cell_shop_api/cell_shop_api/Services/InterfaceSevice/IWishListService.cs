using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IWishListService
    {
        Task<IList<WishList>> GetWishListAsync();
        Task<bool> DeleteWishListAsync(int id);
        Task<bool> AddWishListAsync(int productId);
    }
}
