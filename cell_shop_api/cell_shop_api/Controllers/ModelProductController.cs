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
    public class ModelProductController : ControllerBase
    {
        private readonly IModelProductService _modelProductService;

        public ModelProductController(IModelProductService modelProductService)
        {
            _modelProductService = modelProductService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listBrand = await _modelProductService.GetAllAsync();

            return Ok(listBrand);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()) || id <= 0)
                return BadRequest();

            var brand = await _modelProductService.GetByIdAsync(id);

            return brand != null ? Ok(brand) : NotFound();
        }
        [HttpPost]
        public IActionResult Add(CreateModelProduct createModelProduct)
        {
            if (createModelProduct == null)
                return BadRequest();

            var result = _modelProductService.Add(createModelProduct);

            return result > 0 ? Ok() : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateModelProduct updateModelProduct)
        {
            if (updateModelProduct == null || updateModelProduct.Id <= 0)
                return BadRequest();

            var result = await _modelProductService.Update(updateModelProduct);

            return result > 0 ? Ok() : BadRequest();
        }
    }
}
