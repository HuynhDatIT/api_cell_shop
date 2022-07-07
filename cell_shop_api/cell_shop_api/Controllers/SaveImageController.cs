using cell_shop_api.Enum;
using cell_shop_api.Services.InterfaceSevice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaveImageController : ControllerBase
    {
        private ISaveImageService saveImageService;

        public SaveImageController(ISaveImageService saveImageService)
        {
            this.saveImageService = saveImageService;
        }

        [HttpPost]
        public async Task<IActionResult> save (IList<IFormFile> formFile)
        {
            foreach (var item in formFile)
            {
                var path = await saveImageService.SaveImageAsync(item, TypeImage.ImageProduct);

            }
            return Ok();
        }
    }
}
