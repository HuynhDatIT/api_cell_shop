namespace cell_shop_api.ViewModels.Request
{
    public class CreateCart
    {
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
