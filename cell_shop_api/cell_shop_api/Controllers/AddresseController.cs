using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using System.Threading.Tasks;

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddresseController : ControllerBase
    {
        private readonly IAddressesService _addressesService;

        public AddresseController(IAddressesService addressesService)
        {
            _addressesService = addressesService;
        }
        [AuthorizeFilterAttribute("user","admin")]
        [HttpGet]
        public async Task<IActionResult> GetAddresseAccount()
        {
            var addresses = await _addressesService.GetAddressesByAccountAsync();

            return addresses != null ? Ok(addresses) : NotFound();
        }
        [AuthorizeFilterAttribute("user")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAddresse updateAddresse)
        {
            var result = await _addressesService.UpdateAddresseAsync(updateAddresse);

            return result ? Ok() : BadRequest();
        }
        [AuthorizeFilterAttribute("user", "admin")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateAddresse createAddresse)
        {
            var result = await _addressesService.CreateAddresseAsync(createAddresse);

            return result ? Ok() : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _addressesService.DeleteAddresseAsync(id);

            return result ? Ok() : BadRequest();
        }
    }
}
