using cell_shop_api.Base.Interface;
using CellShop_Api.Models;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.Interface
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<Role> GetRoleByNameAsync(string name);
    }
}
