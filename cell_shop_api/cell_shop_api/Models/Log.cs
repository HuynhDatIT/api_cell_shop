using cell_shop_api.Base.Interface;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Log 
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public DateTime Time { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
