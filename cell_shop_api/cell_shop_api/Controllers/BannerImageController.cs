using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerImageController : ControllerBase
    {
        private readonly IBannerImageService _bannerImageService;

        public BannerImageController(IBannerImageService bannerImageService)
        {
            _bannerImageService = bannerImageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBannerImage()
        {
            var result = await _bannerImageService.GetAllBannerImageAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBannerImage([FromForm] CreateBannerImage createBannerImage)
        {
            var result = await _bannerImageService.CreateBannerImageAnsyc(createBannerImage);
            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdeteBannerImage([FromForm] UpdateBannerImage updateBannerImage)
        {
            var result = await _bannerImageService.UpdateBannerImageAnsyc(updateBannerImage);
            return result ? Ok() : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBannerImage(int bannerId)
        {
            var result = await _bannerImageService.DelteBannerImageAnsyc(bannerId);
            return result ? Ok() : BadRequest();
        }
    }
}
