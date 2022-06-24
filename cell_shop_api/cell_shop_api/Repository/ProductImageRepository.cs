using cell_shop_api.Base.Interface;
using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.Interface;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Data;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Repository
{
    public class ProductImageRepository : BaseRepositoryCURD<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(CellShopDbContext db) : base(db)
        {
        }

        public async Task<IEnumerable<ProductImage>> GetProductImageByProductIdAsync(int productId)
        {
            var productimage = await _dbSet.Where(x => x.ProductId == productId 
                                            && x.Status == true)
                                            .ToListAsync();
            return productimage;
        }
    }
}
