using CellShop_Api.Models;

namespace cell_shop_api.ViewModels.Response
{
    public class GetModelProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }
        public string CategorieName { get; set; }
        public string BrandName { get; set; }
    }
}
