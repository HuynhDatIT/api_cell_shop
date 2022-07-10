using cell_shop_api.Base.Interface;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class ProductImage : IBaseModel
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public bool Status { get ; set ; }
    }
}
