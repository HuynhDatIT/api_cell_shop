using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace cell_shop_api.ViewModels.Request
{
    public class UpdateProductImage
    {
        public int ProductId { get; set; }
        public IList<IFormFile> formFiles { get; set; }
    }
}
