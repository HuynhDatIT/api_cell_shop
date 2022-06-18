using cell_shop_api.Services.InterfaceSevice;
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
        private readonly IBrandService BrandService;

        public BrandController(IBrandService brandService)
        {
            BrandService = brandService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBrand()
        {
            var listBrand = await BrandService.GetAllAsync();
            return Ok(listBrand);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var brand = await BrandService.GetByIdAsync(id);
            
            return brand != null ? Ok(brand) : NotFound();  
        }
    
    }
}
