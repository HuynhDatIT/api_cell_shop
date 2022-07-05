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
    public class WishListRepository : BaseRepository<WishList>, IWishListRepository
    {
        public WishListRepository(CellShopDbContext db) : base(db)
        {
        }

        public override async Task<IEnumerable<WishList>> GetAllAsync()
        {
            var listWishList = await _dbSet.ToListAsync();

            return listWishList;
        }

        public override async Task<WishList> GetByIdAsync(int id)
        {
            var wishlist = await _dbSet.FindAsync(id);

            return wishlist;    
        }

        public async Task<WishList> GetWishListByProductIdAsync(int accountId, int productId)
        {
            return await _dbSet.FirstOrDefaultAsync
                                (x => x.AccountId == accountId && x.ProductId == productId);
        }

        public async Task<IList<WishList>> GetWishListsAsync(int accountId)
        {
            return await _dbSet.Where(x => x.AccountId == accountId).ToListAsync();
        }
    }
}
