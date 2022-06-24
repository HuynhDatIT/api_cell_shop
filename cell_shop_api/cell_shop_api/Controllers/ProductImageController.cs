using cell_shop_api.Services.InterfaceSevice;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet("{productid}")]
        public async Task<IActionResult> GetByProductId(int productid)
        {
            if (string.IsNullOrEmpty(productid.ToString()) || productid <= 0)
                return BadRequest();

            var productImages = await _productImageService.GetProductImagesByProductIdAsync(productid);

            return Ok(productImages);
        }
    }
}
