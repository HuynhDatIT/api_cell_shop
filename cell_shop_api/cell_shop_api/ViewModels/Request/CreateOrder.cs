using System;
using System.Collections.Generic;

namespace cell_shop_api.ViewModels.Request
{
    public class CreateOrder
    {
        public int Discount { get; set; }
        public float Total { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public IList<CreateInvoiceDetail> invoiceDetails { get; set; }
    }
}
