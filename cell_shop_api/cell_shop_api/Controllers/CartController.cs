using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cell_shop_api.Controllers
{
    [AuthorizeFilter(role: "user")]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        [HttpGet]
        public async Task<IActionResult> GetByAccout()
        {
            var brand = await _cartService.GetCartsAsync();

            return brand != null ? Ok(brand) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateCart createCart)
        {
            var result = await _cartService.AddAsync(createCart);

            return result ? Ok() : BadRequest();
        }
        [HttpDelete("{cartId}")]
        public async Task<IActionResult> Delete(int cartId)
        {
            var result = await _cartService.DeleteAsync(cartId);

            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCart updateCart)
        {
            var result = await _cartService.UpdateAsync(updateCart);

            return result ? Ok() : BadRequest();
        }

    }
}
