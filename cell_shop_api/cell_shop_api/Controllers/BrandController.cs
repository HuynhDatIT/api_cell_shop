using cell_shop_api.Helper;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CellShop_Api.Controllers
{
    [AuthorizeFilterAttribute("admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listBrand = await _brandService.GetAllAsync();

            return Ok(listBrand);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _brandService.GetByIdAsync(id);

            return brand != null ? Ok(brand) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrand createBrand)
        {
            var result = await _brandService.AddAsync(createBrand);

            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(GetBrand getBrand)
        {
            var result = await _brandService.UpdateAsync(getBrand);

            return result ? Ok() : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _brandService.DeleteAsync(id);

            return result ? Ok() : BadRequest();
        }

    }
}
