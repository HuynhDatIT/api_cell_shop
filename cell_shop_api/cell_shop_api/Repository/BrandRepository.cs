using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.InheritRepository.Interface;
using CellShop_Api.Data;
using CellShop_Api.Models;
using System.Linq;

namespace cell_shop_api.Repository
{
    public class BrandRepository : BaseRepositoryCURD<Brand>, IBrandRepository
    {
        public BrandRepository(CellShopDbContext db) : base(db)
        {
        }

        public bool IsNameExist(string name)
        {
            return _dbSet.Where(x => x.Name == name && x.Status == true).Count() > 0;
        }
    }
}
