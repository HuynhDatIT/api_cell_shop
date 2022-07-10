using cell_shop_api.Base.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Addresse : IBaseModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
