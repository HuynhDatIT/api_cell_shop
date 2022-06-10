using CellShop_Api.Interface;
using CellShop_Api.Interface.IServices;
using CellShop_Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CellShop_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IGenericService<Categorie> CategorieService;

        public CategoriesController(IGenericService<Categorie> categorieService)
        {
            CategorieService = categorieService;
        }



        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<IList<Categorie>> Get()
        {
            var listItem = await CategorieService.GetAll();
            
            return listItem;
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public async Task<Categorie> Get(int id)
        {
            var item = await CategorieService.GetById(id);
            return item;
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
