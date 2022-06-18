namespace CellShop_Api.ViewModels
{
    public class GetProduct
    {
        public int Id { get; set; }
       
        public string Color { get; set; }
        public int Ram { get; set; }
        public int Rom { get; set; }
  
        public float Price { get; set; }
       
        public int Stock { get; set; }
        public float Rating { get; set; } = 0;
        public int ModelProductId { get; set; }
    }
}
