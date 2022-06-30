using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IBrandService : IBaseService<GetBrand>
    {
        Task<bool> AddAsync(CreateBrand brand);
        Task<bool> UpdateAsync(GetBrand getBrand);
    }
}
