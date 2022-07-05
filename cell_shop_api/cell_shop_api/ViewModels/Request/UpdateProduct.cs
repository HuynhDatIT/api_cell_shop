namespace cell_shop_api.ViewModels.Request
{
    public class UpdateProduct
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Ram { get; set; }
        public int Rom { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public int ModelProductId { get; set; }
    }
}
