using cell_shop_api.Base.Interface;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class InvoiceDetail : IBaseModel
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public bool Status { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

    }
}
