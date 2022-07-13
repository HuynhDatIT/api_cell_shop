using Microsoft.AspNetCore.Http;

namespace cell_shop_api.ViewModels.Request
{
    public class CreateBannerImage
    {
        public int ProductId { get; set; }
        public string Content { get; set; }
        public IFormFile File { get; set; }
        public int Position { get; set; }
        public bool IsActive { get; set; }
    }
}
