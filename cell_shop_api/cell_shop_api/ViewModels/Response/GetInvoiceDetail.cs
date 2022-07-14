namespace cell_shop_api.ViewModels.Response
{
    public class GetInvoiceDetail
    {
        public int Id { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
    }
}
