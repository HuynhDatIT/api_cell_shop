namespace cell_shop_api.ViewModels.Request
{
    public class CreateModelProduct
    {
        public string Name { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }
        public int CategorieId { get; set; }
        public int BrandId { get; set; }
    }
}
