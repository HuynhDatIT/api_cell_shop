using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.InheritRepository.Interface;
using CellShop_Api.Data;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Repository
{
    public class BrandRepository : BaseRepositoryCURD<Brand>, IBrandRepository
    {
        public BrandRepository(CellShopDbContext db) : base(db)
        {
        }

        public async Task<Brand> GetBrandByName(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Name == name && x.Status == true);
        }
    }
}
