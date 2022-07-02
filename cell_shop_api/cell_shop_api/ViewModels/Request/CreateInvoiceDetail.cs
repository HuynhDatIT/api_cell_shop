namespace cell_shop_api.ViewModels.Request
{
    public class CreateInvoiceDetail
    {
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
    }
}
