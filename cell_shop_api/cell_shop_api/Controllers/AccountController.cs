using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cell_shop_api.Controllers
{
    [AuthorizeFilter("admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listAccount = await _accountService.GetAllAsync();

            return Ok(listAccount);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _accountService.GetByIdAsync(id);

            return account != null ? Ok(account) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateAccount createAccount)
        {
            var result = await _accountService.AddAsync(createAccount);

            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAccount updateAccount)
        {
            var result = await _accountService.UpdateAsync(updateAccount);

            return result ? Ok() : BadRequest();
        }
        [HttpDelete("{accountId}")]
        public async Task<IActionResult> Delete(int accountId)
        {
            var result = await _accountService.DeleteAsync(accountId);

            return result ? Ok() : BadRequest();
        }
    }
}
