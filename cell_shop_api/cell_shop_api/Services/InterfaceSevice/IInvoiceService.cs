using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IInvoiceService
    {
        Task<IEnumerable<GetInvoice>> GetAllAsync();

        Task<DeliveryStatus?> ChangeStatusInvocie(int invoiceId);
        Task<DeliveryStatus?> CancelInvocieAsync(int invoiceId);
    }
}
