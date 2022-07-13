using cell_shop_api.Base.Interface;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.Interface
{
    public interface IInvoiceRepository : IBaseRepository<Invoice>
    {
        Task<IList<Invoice>> GetInvoiceByAccountAsync(int accountId);
    }
}
