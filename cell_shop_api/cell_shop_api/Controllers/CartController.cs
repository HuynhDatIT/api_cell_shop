using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByAccoutId(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()) || id <= 0)
                return BadRequest();

            var brand = await _cartService.GetCartsAsync(id);

            return brand != null ? Ok(brand) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateCart createCart)
        {
            if (createCart == null || createCart.Quantity <= 0)
                return BadRequest();

            var result = await _cartService.AddAsync(createCart);

            return result > 0 ? Ok() : BadRequest(); 
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int cartid)
        {
            if (cartid <= 0)
                return BadRequest();

            var result = await _cartService.DeleteAsync(cartid);

            return result > 0 ? Ok() : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCart updateCart)
        {
            if (updateCart == null || updateCart.Quantity <= 0)
                return BadRequest();

            var result = await _cartService.UpdateAsync(updateCart);

            return result > 0 ? Ok() : BadRequest();
        }

    }
}
