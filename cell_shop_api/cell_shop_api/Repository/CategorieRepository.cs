using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.InheritRepository.Interface;
using CellShop_Api.Data;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Repository
{
    public class CategorieRepository : BaseRepositoryCURD<Categorie>, ICategorieRepository
    {
        public CategorieRepository(CellShopDbContext db) : base(db)
        {
        }

        public async Task<Categorie> GetCategorieByName(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(
                                x => x.Name == name && x.Status == true);
        }
    }
}
