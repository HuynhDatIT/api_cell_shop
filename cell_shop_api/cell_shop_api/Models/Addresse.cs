using cell_shop_api.Base.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Addresse : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Phone { get; set; }
        public bool Status { get; set; }
        [Required]
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
