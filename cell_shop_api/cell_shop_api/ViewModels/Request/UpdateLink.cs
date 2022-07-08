using System.ComponentModel.DataAnnotations;

namespace cell_shop_api.ViewModels.Request
{
    public class UpdateLink
    {
        public int Id { get; set; }
        public string PathLink { get; set; }
        [Required]
        public string Title { get; set; }
        public bool Status { get; set; }
    }
}
