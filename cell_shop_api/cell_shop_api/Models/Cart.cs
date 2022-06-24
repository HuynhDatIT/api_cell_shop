using cell_shop_api.Base.Interface;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Cart : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int AccountId { get; set; }
        public Account Account { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public bool Status { get ; set ; }
    }
}
