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
    public class InvoiceDetailRepository : BaseRepository<InvoiceDetail>, IInvoiceDetailRepository
    {
        public InvoiceDetailRepository(CellShopDbContext db) : base(db)
        {
        }

        public async Task<IList<InvoiceDetail>> GetInvoiceDetailsByInvoiceAsync(int invoiceId)
        {
            return await _dbSet.Where(x => x.Status == true && x.InvoiceId == invoiceId)
                                .ToListAsync();
        }
    }
}
