using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        public Account Account { get; set; }
        public Product Product { get; set; }
    }
}
