using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CellShop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var listBrand = await _brandService.GetAllAsync();
           
            return Ok(listBrand);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()) || id <= 0)
                return BadRequest();

            var brand = await _brandService.GetByIdAsync(id);
            
            return brand != null ? Ok(brand) : NotFound();  
        }
        [HttpPost("add")]
        public IActionResult Add(CreateBrand createBrand)
        {
            if (createBrand == null)
                return BadRequest();
            
            var result = _brandService.Add(createBrand);

            return Ok(result);
        }
        [HttpPut("update")]
        public IActionResult Update(GetBrand getBrand)
        {
            if (getBrand == null)
                return BadRequest();

            var result = _brandService.Update(getBrand);

            return Ok(result);
        }

    }
}
