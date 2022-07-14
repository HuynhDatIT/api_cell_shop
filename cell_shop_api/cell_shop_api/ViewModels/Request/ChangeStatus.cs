using CellShop_Api.Enum;

namespace cell_shop_api.ViewModels.Request
{
    public class ChangeStatus
    {
        public int InvoiceId { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
    }
}
