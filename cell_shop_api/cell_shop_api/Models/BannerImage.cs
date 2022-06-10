using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class BannerImage
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Path { get; set; }
        [Required]
        public int Position { get; set; }
        [DefaultValue(true)]
        public bool IsActive { get; set; } 

        public Product Product { get; set; }
    }
}
