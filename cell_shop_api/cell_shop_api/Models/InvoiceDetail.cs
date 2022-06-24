using cell_shop_api.Base.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class InvoiceDetail : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public bool Status { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

    }
}
