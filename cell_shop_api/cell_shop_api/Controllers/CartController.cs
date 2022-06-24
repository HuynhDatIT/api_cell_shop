using cell_shop_api.Services.InterfaceSevice;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet("getbyaccountid/{id}")]
        public async Task<IActionResult> GetByAccoutId(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()) || id <= 0)
                return BadRequest();

            var brand = await _cartService.GetCarts(id);

            return brand != null ? Ok(brand) : NotFound();
        }
        //[HttpPost("add")]
        //public IActionResult Add(CreateBrand createBrand)
        //{
        //    if (createBrand == null)
        //        return BadRequest();

        //    var result = _brandService.Add(createBrand);

        //    return Ok(result);
        //}
        //[HttpPut("update")]
        //public IActionResult Update(GetBrand getBrand)
        //{
        //    if (getBrand == null)
        //        return BadRequest();

        //    var result = _brandService.Update(getBrand);

        //    return Ok(result);
        //}
    }
}
