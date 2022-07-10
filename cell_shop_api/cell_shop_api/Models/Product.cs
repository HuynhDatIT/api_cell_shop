using cell_shop_api.Base.Interface;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Product : IBaseModel
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Ram { get; set; }
        public int Rom { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public float Rating { get; set; }
        public bool Status { get; set; }
        public int ModelProductId { get; set; }
        public ModelProduct ModelProduct { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<BannerImage> BannerImages { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<WishList> WishLists { get; set; }
    }
}
