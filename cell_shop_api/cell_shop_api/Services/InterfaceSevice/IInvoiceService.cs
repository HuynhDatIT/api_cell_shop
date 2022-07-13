using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IInvoiceService
    {
        Task<IEnumerable<GetInvoice>> GetAllAsync();
    }
}
