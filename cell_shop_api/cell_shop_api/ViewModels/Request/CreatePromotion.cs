using System;
using System.ComponentModel.DataAnnotations;

namespace cell_shop_api.ViewModels.Request
{
    public class CreatePromotion
    { 
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Discount { get; set; }
        public bool Status { get; set; }
    }
}
