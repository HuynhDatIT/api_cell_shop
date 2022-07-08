using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private readonly ILinkService _linkService;
        public LinkController(ILinkService linkService)
        {
            _linkService = linkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listBrand = await _linkService.GetAllAsync();
            return Ok(listBrand);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var link =await _linkService.GetByIdAsync(id);
            return Ok(link);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLink createLink)
        {
            var link =await _linkService.CreateLinkAsync(createLink);
            return Ok(link);
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var result =await _linkService.DeleteLinkAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateLink updateLink)
        {
            var result = await _linkService.UpdateLinkAsync(updateLink);
            return Ok(result);
        }

    }
}
