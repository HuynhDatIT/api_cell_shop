using cell_shop_api.Services.InterfaceSevice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailController : ControllerBase
    {
        private readonly IInvoiceDetailService _invoiceDetailService;

        public InvoiceDetailController(IInvoiceDetailService invoiceDetailService)
        {
            _invoiceDetailService = invoiceDetailService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByInvoiceId(int id)
        {
            var getInvoicDetails = await _invoiceDetailService.GetInvoiceDetailByInvoiceAsync(id);

            return getInvoicDetails != null ? Ok(getInvoicDetails) : BadRequest();
        }
    }
}
