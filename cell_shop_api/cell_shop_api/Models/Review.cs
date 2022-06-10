using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        public float Rating { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; } 
        public Product Product { get; set; }
        public Account Account { get; set; }
    }
}
