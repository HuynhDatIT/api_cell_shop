using cell_shop_api.Base.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Link : IBaseModel
    {
        public int Id { get; set; }
        public string PathLink { get; set; }
        public string Title { get; set; }
        public bool Status { get; set; }

    }
}
