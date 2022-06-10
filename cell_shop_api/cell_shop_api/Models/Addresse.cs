using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Addresse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Phone { get; set; }
        [DefaultValue(true)]
        public bool Status { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}
