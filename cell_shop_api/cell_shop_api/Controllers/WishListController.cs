using cell_shop_api.Services.InterfaceSevice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using System.Threading.Tasks;

namespace cell_shop_api.Controllers
{
    [AuthorizeFilter(role: "user")]
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly IWishListService _wishListService;

        public WishListController(IWishListService wishListService)
        {
            _wishListService = wishListService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWishList()
        {
            var wishLists = await _wishListService.GetWishListAsync();

            return Ok(wishLists);
        }
        [HttpPost]
        public async Task<IActionResult> AddWishList(int productId)
        {
            var result = await _wishListService.AddWishListAsync(productId);

            return result ? Ok() : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteWishList(int id)
        {
            var result = await _wishListService.DeleteWishListAsync(id);

            return result ? Ok() : BadRequest();
        }
    }
}
