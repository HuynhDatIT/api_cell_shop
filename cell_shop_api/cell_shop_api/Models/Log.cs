using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Action { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
        [DefaultValue(true)]
        public bool Status { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
