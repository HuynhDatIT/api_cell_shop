using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using CellShop_Api.Models;
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
            var productImages = await _productImageService
                                        .GetProductImagesByProductIdAsync(productid);

            return Ok(productImages);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImgae([FromForm] UpdateProductImage updateProductImage)
        {
            var result = await _productImageService
                                        .UpdateProductImagesByProductIdAsync(updateProductImage);

            return result ? Ok() : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage([FromForm] int productId)
        {
            var result = await _productImageService.DeleteProductImageRangeAsync(productId);
            return Ok(result);
        }
    }
}
