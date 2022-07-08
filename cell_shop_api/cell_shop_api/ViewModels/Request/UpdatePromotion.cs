using System;
using System.ComponentModel.DataAnnotations;

namespace cell_shop_api.ViewModels.Request
{
    public class UpdatePromotion
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public int Discount { get; set; }
        public bool Status { get; set; }
    }
}
