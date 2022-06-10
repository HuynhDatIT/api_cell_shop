using CellShop_Api.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateInvoice { get; set; } = DateTime.Now;
        
        public int Discount { get; set; } = 0;
        [Required]
        public float Total { get; set; }
        [Required]
        public string DeliveryName { get; set; }
        [Required]
        public string DeliveryPhone { get; set; }
        [Required]
        public string DeliveryAddress { get; set; }

        public DeliveryStatus DeliveryStatus { get; set; } = DeliveryStatus.Order;
       
        public bool Status { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
