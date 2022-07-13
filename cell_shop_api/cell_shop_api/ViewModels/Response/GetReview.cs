namespace cell_shop_api.ViewModels.Response
{
    public class GetReview
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public float Rating { get; set; }
        public int ProductId { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string Path { get; set; }
    }
}
