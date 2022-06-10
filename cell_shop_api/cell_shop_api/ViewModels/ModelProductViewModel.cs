namespace CellShop_Api.ViewModels
{
    public class ModelProductViewModel
    {
        public int Id { get; set; }
       
        public string Name { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }

        public int CategorieId { get; set; }
        public int BrandId { get; set; }
    }
}
