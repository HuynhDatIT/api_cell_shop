using Microsoft.AspNetCore.Http;

namespace cell_shop_api.ViewModels.Request
{
    public class UpdateBannerImage
    {
        public string Id { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public IFormFile File { get; set; }
        public int Position { get; set; }
        public bool IsActive { get; set; }
    }
}
