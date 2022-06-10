using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class ProductImage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Path { get; set; }
        public Product Product { get; set; }
    }
}
