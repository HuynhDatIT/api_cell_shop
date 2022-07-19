using CellShop_Api.Enum;
using System;

namespace cell_shop_api.ViewModels.Request
{
    public class EmailRequest
    {
        public DateTime DateInvoice { get; set; }
        public float Total { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public string To { get; set; }
        public string AccountName { get; set; }
    }
}
