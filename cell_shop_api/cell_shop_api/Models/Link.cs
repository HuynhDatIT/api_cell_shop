using cell_shop_api.Base.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Link : IBaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PathLink { get; set; }
        [Required]
        public string Title { get; set; }
        public bool Status { get; set; }

    }
}
