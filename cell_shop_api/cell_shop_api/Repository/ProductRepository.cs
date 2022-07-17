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
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(CellShopDbContext db) : base(db)
        {
        }

        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            var listItem = await _dbSet
                                    .Include(x => x.ModelProduct)
                                    .Where(x => x.Status == true)
                                    .ToListAsync();

            return listItem;
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            var item = await _dbSet
                                    .Include(x => x.ModelProduct.Brand)
                                    .Include(x => x.ModelProduct.Categorie)
                                    .Where(x => x.Status == true && x.Id == id)
                                    .FirstOrDefaultAsync();

            return item;
        }

        public async Task<IList<Product>> GetProductByModelIdAsync(int modelId)
        {
            var products = await _dbSet
                                    .Include(x => x.ModelProduct.Brand)
                                    .Include(x => x.ModelProduct.Categorie)
                                    .Where(x => x.Status == true && x.ModelProductId == modelId)
                                    .ToListAsync();

            return products;
        }
        public async Task<IList<Product>> GetProductsByCatagorieAsync(int catogorieId)
        {
            return await _dbSet.Include(x => x.ModelProduct.Categorie)
                                .Where(x => x.ModelProduct.CategorieId == catogorieId)
                                .OrderByDescending(x => x.Id).ToListAsync();
        }
       
    }
}
