using cell_shop_api.Base.Interface;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.InheritRepository.Interface
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<IList<Product>> GetProductByModelIdAsync(int modelId);
        Task<IList<Product>> GetProductsByCatagorieAsync(int catogorieId);

    }
}
