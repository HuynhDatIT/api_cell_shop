using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Request;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.Interface
{
    public interface ICartRepository : IBaseRepository<Cart>
    {
        Task<IEnumerable<Cart>> GetCartByAccountIdAsync(int accountid);
        Task<Cart> GetCartByProductAsync(int productId, int accountId);
        Task<IList<Cart>> GetCartByProductIdAsync(int productId);
    }
}
