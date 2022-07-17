using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.InheritRepository.Interface;
using CellShop_Api.Data;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Repository
{
    public class ModelProductRepository : BaseRepository<ModelProduct>, IModelProductRepository
    {
        public ModelProductRepository(CellShopDbContext db) : base(db)
        {
        }

        public override async Task<IEnumerable<ModelProduct>> GetAllAsync()
        {
            var listModelProduct = await _dbSet.Include(x => x.Categorie)
                                               .Include(x => x.Brand)
                                               .Where(x => x.Status == true)
                                               .ToListAsync();
            return listModelProduct;
        }

        public override async Task<ModelProduct> GetByIdAsync(int id)
        {
            var modelProduct = await _dbSet.Include(x => x.Categorie)
                                           .Include(x => x.Brand)
                                           .Where(x => x.Status == true && x.Id == id)
                                           .FirstOrDefaultAsync();
            return modelProduct;
        }

        public async Task<ModelProduct> GetModelProductByNameAsync(string name)
        {
            return await _dbSet.FirstOrDefaultAsync(
                                x => x.Name == name && x.Status == true);
        }
        public async Task<IList<ModelProduct>> GetModelProductByCategorieAsync(int categorieId)
        {
            return await _dbSet
                            .Include(x => x.Categorie)
                            .Include(x => x.Brand)
                            .Where(x => x.CategorieId == categorieId && x.Status == true)
                            .OrderByDescending(x => x.Id)
                            .ToListAsync();
        }

        public async Task<IList<ModelProduct>> GetModelProductByBrandAsync(int brandId)
        {
            return await _dbSet
                            .Include(x => x.Categorie)
                            .Include(x => x.Brand)
                            .Where(x => x.BrandId == brandId && x.Status == true)
                            .OrderByDescending(x => x.Id)
                            .ToListAsync();
        }
    }
}
