using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CellShop_Api.Models
{
    public class ModelProduct
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Specification { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Categorie Categorie { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
