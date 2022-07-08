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
    public class AddressesRepository : BaseRepository<Addresse>, IAddressesRepository
    {
        public AddressesRepository(CellShopDbContext db) : base(db)
        {
        }

        public async Task<IList<Addresse>> GetAddressesByAccountIdAsync(int accountId)
        {
            return await _dbSet.Where(x => x.Status == true && x.AccountId == accountId)
                                .ToListAsync();
        }
    }
}
