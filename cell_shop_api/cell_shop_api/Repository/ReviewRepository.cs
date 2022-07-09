using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.Interface;
using CellShop_Api.Data;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Repository
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(CellShopDbContext db) : base(db)
        {
        }

        public async Task<IList<Review>> GetReviewbyProductAsync(int productId)
        {
            return await _dbSet.Where(x => x.Status == true && x.ProductId == productId)
                                .ToListAsync();
        }
    }
}
