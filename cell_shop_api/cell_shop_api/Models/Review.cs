using cell_shop_api.Base.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Review : IBaseModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public float Rating { get; set; }
        public bool Status { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
