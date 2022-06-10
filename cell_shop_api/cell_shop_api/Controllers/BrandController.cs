using CellShop_Api.Interface;
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
        private readonly IGenericService<Brand> BrandService;

        public BrandController(IGenericService<Brand> brandService)
        {
            BrandService = brandService;
        }



        // GET: api/<BrandController>
        [HttpGet]
        public  async Task<IList<Brand>> Get()
        {
            var listItem = await BrandService.GetAll();
            return listItem;
        }

        // GET api/<BrandController>/5
        [HttpGet("{id}")]
        public async Task<Brand> Get(int id)
        {
            var item = await BrandService.GetById(id);

            return item;
        }

        // POST api/<BrandController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BrandController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BrandController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
