using cell_shop_api.Base.Interface;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class ModelProduct : IBaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public int CategorieId { get; set; }
        public Categorie Categorie { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
