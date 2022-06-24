using CellShop_Api.Models;

namespace cell_shop_api.ViewModels.Response
{
    public class GetProduct
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Ram { get; set; }
        public int Rom { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public float Rating { get; set; }
        public int ModelProductId { get; set; }
        public string ModelProductName { get; set; }
    }
}
