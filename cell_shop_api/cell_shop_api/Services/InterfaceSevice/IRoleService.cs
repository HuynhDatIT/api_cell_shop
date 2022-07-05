using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IRoleService : IBaseService<GetRole>
    {
        Task<bool> CreateRoleAsync(string name);
        Task<bool> UpdateRoleAsync(UpdateRole updateRole);
        Task<bool> DeleteRoleAsync(int id);
    }
}
