using CellShop_Api.Enum;
using System;

namespace cell_shop_api.ViewModels.Request
{
    public class EmailRequest
    {
        public string DateInvoice { get { return DateInvoice; } set { DateInvoice = string.Format("dddd, dd MMMM yyyy HH:mm:ss", DateInvoice); } }
        public int Discount { get; set; } = 0;
        public float Total { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public string To { get; set; }
        public string AccountName { get; set; }
    }
}
