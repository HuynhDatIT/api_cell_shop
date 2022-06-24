using cell_shop_api.Services.InterfaceSevice;
using Microsoft.AspNetCore.Mvc;
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
            if (string.IsNullOrEmpty(id.ToString()) || id <= 0)
                return BadRequest();

            var product = await _productService.GetByIdAsync(id);

            return product != null ? Ok(product) : NotFound();
        }
        //[HttpPost("add")]
        //public IActionResult Add()
        //{
        //    if (createBrand == null)
        //        return BadRequest();

        //    var result = _productService.Add(createBrand);

        //    return Ok(result);
        //}
        //[HttpPut("update")]
        //public IActionResult Update(GetBrand getBrand)
        //{
        //    if (getBrand == null)
        //        return BadRequest();

        //    var result = _productService.Update(getBrand);

        //    return Ok(result);
        //}
    }
}
