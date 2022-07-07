using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace cell_shop_api.ViewModels.Request
{
    public class CreateProduct
    {
        public string Color { get; set; }
        public int Ram { get; set; }
        public int Rom { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public int ModelProductId { get; set; }
        public IList<IFormFile> formFiles { get; set; }
    }
}
