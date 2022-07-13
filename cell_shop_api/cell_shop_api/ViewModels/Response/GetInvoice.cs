using CellShop_Api.Enum;
using System;

namespace cell_shop_api.ViewModels.Response
{
    public class GetInvoice
    {
        public int Id { get; set; }
        public DateTime DateInvoice { get; set; }
        public int Discount { get; set; }
        public float Total { get; set; }
        public string DeliveryName { get; set; }
        public string DeliveryPhone { get; set; }
        public string DeliveryAddress { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public int AccountId { get; set; }
    }
}
