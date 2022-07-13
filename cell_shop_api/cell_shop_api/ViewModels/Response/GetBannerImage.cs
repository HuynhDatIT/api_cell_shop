namespace cell_shop_api.ViewModels.Response
{
    public class GetBannerImage
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Path { get; set; }
        public int Position { get; set; }
        public bool IsActive { get; set; }
        public int ProductId { get; set; }
        public bool Status { get; set; }
    }
}
