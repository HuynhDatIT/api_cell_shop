using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await _roleService.GetAllAsync();
         
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = await _roleService.GetByIdAsync(id);
           
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string name)
        {
            var result = await _roleService.CreateRoleAsync(name);

            return result ? Ok() : BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateRole updateRole)
        {
            var result = await _roleService.UpdateRoleAsync(updateRole);
            
            return result ? Ok() : BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
          
            return result ? Ok() : BadRequest();
        }
    }
}
