using cell_shop_api.Base.Interface;
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
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(CellShopDbContext db) : base(db)
        {
        }

        public async Task<IList<Invoice>> GetInvoiceByAccountAsync(int accountId)
        {
            return await _dbSet.Where(x => x.Status == true && x.AccountId == accountId)
                                .ToListAsync();
        }

        public override async Task<Invoice> GetByIdAsync(int id)
        {
            return await _dbSet.Include(x => x.InvoiceDetails)
                               .FirstOrDefaultAsync(x => x.Status == true && x.Id == id);
        }
    }
}
