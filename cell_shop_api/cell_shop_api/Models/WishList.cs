using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class WishList
    {
        [Key]
        public int Id { get; set; }
        public Account Account { get; set; }
        public Product Product { get; set; }
    }
}
