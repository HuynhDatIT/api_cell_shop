using cell_shop_api.Base.Interface;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Promotion : IBaseModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Discount { get; set; }
        public bool Status { get; set; } 
    }
}
