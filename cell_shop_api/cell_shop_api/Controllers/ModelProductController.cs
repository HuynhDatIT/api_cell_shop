using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
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
            var listmodelProducts = await _modelProductService.GetAllAsync();

            return Ok(listmodelProducts);
        }
        [HttpGet("categorie/{categorieId}")]
        public async Task<IActionResult> GetModelProductByCategorie(int categorieId)
        {
            var listmodelProducts = await _modelProductService
                                        .GetModelProductbyCategorieAsync(categorieId);

            return listmodelProducts != null ? Ok(listmodelProducts) : NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (string.IsNullOrEmpty(id.ToString()) || id <= 0)
                return BadRequest();

            var modelProduct = await _modelProductService.GetByIdAsync(id);

            return modelProduct != null ? Ok(modelProduct) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateModelProduct createModelProduct)
        {
            var result = await _modelProductService.AddAsync(createModelProduct);

            return result ? Ok() : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateModelProduct updateModelProduct)
        {
            var result = await _modelProductService.UpdateAsync(updateModelProduct);

            return result ? Ok() : BadRequest();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _modelProductService.DeleteModelProductAsync(id);

            return result ? Ok() : BadRequest();
        }
    }
}
