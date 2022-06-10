using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class InvoiceDetail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
        public Product Product { get; set; }
        public Invoice Invoice { get; set; }

    }
}
