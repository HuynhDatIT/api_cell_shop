using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace cell_shop_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieService _categorieService;

        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var listCategorie = await _categorieService.GetAllAsync();

            return Ok(listCategorie);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var brand = await _categorieService.GetByIdAsync(id);

            return brand != null ? Ok(brand) : NotFound();
        }
        [AuthorizeFilterAttribute("admin")]

        [HttpPost]
        public async Task<IActionResult> Add(CreateCategorie createCategorie)
        {
            var result = await _categorieService.AddAsync(createCategorie);

            return result ? Ok() : BadRequest();
        }
        [AuthorizeFilterAttribute("admin")]

        [HttpPut]
        public async Task<IActionResult> Update(GetCategorie getCategorie)
        {
            var result = await _categorieService.UpdateAsync(getCategorie);

            return result ? Ok() : BadRequest();
        }
        [AuthorizeFilterAttribute("admin")]

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _categorieService.DeleteAsync(id);

            return result ? Ok() : BadRequest();
        }
    }
}
