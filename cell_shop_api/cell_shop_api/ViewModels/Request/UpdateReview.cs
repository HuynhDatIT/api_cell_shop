namespace cell_shop_api.ViewModels.Request
{
    public class UpdateReview
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public float Rating { get; set; }
        public int ProductId { get; set; }
    }
}
