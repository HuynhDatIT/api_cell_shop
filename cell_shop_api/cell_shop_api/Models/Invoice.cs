using cell_shop_api.Base.Interface;
using CellShop_Api.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Invoice : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DateInvoice { get; set; }
        public int Discount { get; set; } = 0;
        [Required]
        public float Total { get; set; }
        [Required]
        public string DeliveryName { get; set; }
        [Required]
        public string DeliveryPhone { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public bool Status { get; set; }
        [Required]
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
