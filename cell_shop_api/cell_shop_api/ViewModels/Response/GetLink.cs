using System.ComponentModel.DataAnnotations;

namespace cell_shop_api.ViewModels.Response
{
    public class GetLink
    {
        public int Id { get; set; }
        [Required]
        public string PathLink { get; set; }
        [Required]
        public string Title { get; set; }
        public bool Status { get; set; }
    }
}
