using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listproduct = await _productService.GetAllAsync();

            return Ok(listproduct);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            return product != null ? Ok(product) : NotFound();
        }
        [HttpGet("model/{modelId}")]
        public async Task<IActionResult> GetProductByModelId(int modelId)
        {

            var product = await _productService.GetProductByModelIdAsync(modelId);

            return product != null ? Ok(product) : NotFound();
        }
        [AuthorizeFilterAttribute("admin")]

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm]CreateProduct createProduct)
        {
           var result = await _productService.CreateProductAsync(createProduct);

            return result ? Ok() : BadRequest();
        }
        [AuthorizeFilterAttribute("admin")]

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProduct updateProduct)
        {
            var result = await _productService.UpdateProductAsync(updateProduct);

            return result ? Ok() : BadRequest();
        }
        [AuthorizeFilterAttribute("admin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProductAsync(id);

            return result ? Ok() : BadRequest();
        }
        [HttpGet("categorie/{categorieId}")]
        public async Task<IActionResult> GetProductByCategorie(int categorieId)
        {
            var getProducts = await _productService.GetProductsByCatagorieAsync(categorieId);

            return Ok(getProducts);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> GetProductByCategorie(int? categorieId = null, int? brandId = null, string? name = null)
        {
            var getProducts = await _productService.SearchProductAsync(categorieId, brandId, name);

            return Ok(getProducts);
        }
    }
}
