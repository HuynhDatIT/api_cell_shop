using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.Interface;
using cell_shop_api.ViewModels.Request;
using CellShop_Api.Data;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Repository
{
    public class CartRepository : BaseRepository<Cart> , ICartRepository
    {
        public CartRepository(CellShopDbContext db) : base(db)
        {
        }

        public override async Task<IEnumerable<Cart>> GetAllAsync()
        {
            var listCart = await _dbSet
                                    .Include(x => x.Account)
                                    .Include(x => x.Product)
                                    .ToListAsync();
            
            return listCart;
        }

        public async Task<IEnumerable<Cart>> GetCartByAccountIdAsync(int accountid)
        {
            var listcart = await _dbSet
                                  .Include(x => x.Product)
                                  .Where(x => x.AccountId == accountid)
                                  .ToListAsync();
            return listcart;
        }

        public async Task<Cart> IsProductAccountExistAsync(int productId, int accountId)
        {
            var cart = await _dbSet.Where(x => x.AccountId == accountId
                                         && x.ProductId == productId)
                                    .FirstOrDefaultAsync();
            return cart;
        }
    }
}
