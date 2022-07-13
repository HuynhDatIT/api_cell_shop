using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register register)
        {
            var result = await _userAccountService.RegisterAsync(register);

            return result ? Ok() : BadRequest();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(Login login)
        {
            var token = await _userAccountService.AuthenticaAsync(login);

            return token.TokenJWT != null ? Ok(token) : BadRequest(token.Messeges);
        }
        [HttpPut("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword forgotPassword)
        {
            var result = await _userAccountService.ForgotPasswordAsync(forgotPassword);

            return result ? Ok() : BadRequest();
        }
        [AuthorizeFilterAttribute("user")]
        [HttpPut("UpdateProfile")]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfile updateProfile)
        {
            var result = await _userAccountService.UpdateProfileAsync(updateProfile);

            return result ? Ok() : BadRequest();
        }
        [AuthorizeFilterAttribute("user")]
        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var profile = await _userAccountService.GetProfileAsync();

            return Ok(profile);
        }
    }
}
