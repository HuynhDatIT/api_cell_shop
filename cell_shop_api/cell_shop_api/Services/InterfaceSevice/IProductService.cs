using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IProductService 
    {
        Task<IEnumerable<GetProduct>> GetAllAsync();
        Task<GetProductId> GetByIdAsync(int id);
    }
}
