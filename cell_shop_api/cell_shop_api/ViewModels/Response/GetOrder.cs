using cell_shop_api.ViewModels.Request;
using System.Collections.Generic;

namespace cell_shop_api.ViewModels.Response
{
    public class GetOrder
    {
        public int Id { get; set; }
        public int Discount { get; set; }
        public float Total { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public IList<CreateInvoiceDetail> invoiceDetails { get; set; }
    }
}
