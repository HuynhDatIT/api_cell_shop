using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool Status { get; set; }
        public Role Role { get; set; }
        public ICollection<Log> Logs { get; set; }
        public ICollection<Addresse> Addresses { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<WishList> WishLists { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
