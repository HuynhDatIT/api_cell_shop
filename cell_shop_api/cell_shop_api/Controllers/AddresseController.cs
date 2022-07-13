using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        
        [HttpGet("accountId")]
        public async Task<IActionResult> GetAddresseAccount(int accountId)
        {
            var addresses = await _addressesService.GetAddressesByAccountAsync(accountId);

            return addresses != null ? Ok(addresses) : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAddresse updateAddresse)
        {
            var result = await _addressesService.UpdateAddresseAsync(updateAddresse);

            return result ? Ok() : BadRequest();
        }
        [HttpPost]
        public IActionResult Create(CreateAddresse createAddresse)
        {
            var result = _addressesService.CreateAddresse(createAddresse);

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
