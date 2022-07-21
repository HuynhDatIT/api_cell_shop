using cell_shop_api.Base.Interface;

namespace CellShop_Api.Models
{
    public class BannerImage : IBaseModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Path { get; set; }
        public int Position { get; set; }
        public bool IsActive { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public bool Status { get ; set ; }
    }
}
