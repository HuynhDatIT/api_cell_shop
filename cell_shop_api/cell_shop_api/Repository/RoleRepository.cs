using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.Interface;
using CellShop_Api.Data;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace cell_shop_api.Repository
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(CellShopDbContext db) : base(db)
        {
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Status == true && x.Name == name);
        }

    }
}
