namespace cell_shop_api.ViewModels.Request
{
    public class CreateReview
    {
        public string Content { get; set; }
        public float Rating { get; set; }
        public int ProductId { get; set; }
    }
}
