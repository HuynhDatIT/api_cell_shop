using cell_shop_api.Services.InterfaceSevice;
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
    }
}
