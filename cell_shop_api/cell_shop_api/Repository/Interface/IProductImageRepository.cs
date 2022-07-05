using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.Interface
{
    public interface IProductImageRepository : IBaseRepository<ProductImage>
    {
        Task<IList<ProductImage>> GetProductImageByProductIdAsync(int productId);

        
    }
}
