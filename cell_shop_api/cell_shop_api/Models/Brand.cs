using cell_shop_api.Base.Interface;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Brand : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public ICollection<ModelProduct> ModelProducts { get; set; }

    }
}
