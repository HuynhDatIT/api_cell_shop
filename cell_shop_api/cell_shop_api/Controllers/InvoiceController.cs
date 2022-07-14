using cell_shop_api.Services.InterfaceSevice;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _invoiceService.GetAllAsync();

            return Ok(invoices);
        }
        [HttpPut("ChangeStatus/{invoiceId}")]
        public async Task<IActionResult> UpdateStatus(int invoiceId)
        {
            var invoiceStatus = await _invoiceService.ChangeStatusInvocie(invoiceId);

            return invoiceStatus != null ? Ok(invoiceStatus) : BadRequest();
        }
        [HttpPut("Cancel/{invoiceId}")]
        public async Task<IActionResult> CancelStatus(int invoiceId)
        {
            var invoiceStatus = await _invoiceService.CancelInvocieAsync(invoiceId);

            return invoiceStatus != null ? Ok(invoiceStatus) : BadRequest();
        }
    }
}
