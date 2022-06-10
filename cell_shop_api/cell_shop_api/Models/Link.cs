using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Link
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PathLink { get; set; }
        [Required]
        public string Title { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }

    }
}
