using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using Microsoft.AspNetCore.Mvc;
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
            if (string.IsNullOrEmpty(id.ToString()) || id <= 0)
                return BadRequest();

            var brand = await _categorieService.GetByIdAsync(id);

            return brand != null ? Ok(brand) : NotFound();
        }
        [HttpPost]
        public IActionResult Add(CreateCategorie createCategorie)
        {
            if (createCategorie == null)
                return BadRequest();

            var result = _categorieService.Add(createCategorie);

            return Ok(result);
        }
        [HttpPut]
        public IActionResult Update(GetCategorie getCategorie)
        {
            if (getCategorie == null || getCategorie.Id <= 0)
                return BadRequest();

            var result = _categorieService.Update(getCategorie);

            return Ok(result);
        }
    }
}
