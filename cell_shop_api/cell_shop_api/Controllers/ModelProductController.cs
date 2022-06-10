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
    public class ModelProductController : ControllerBase
    {


        private readonly IGenericService<ModelProduct> ModelProductService;

        public ModelProductController(IGenericService<ModelProduct> modelProductService)
        {
            ModelProductService = modelProductService;
        }

        // GET: api/<ModelProductController>
        [HttpGet]
        public async Task<IList<ModelProduct>> Get()
        {
            var list = await ModelProductService.GetAll();

            return list;
        }

        // GET api/<ModelProductController>/5
        [HttpGet("{id}")]
        public async Task<ModelProduct> Get(int id)
        {
            var item = await ModelProductService.GetById(id);
            return item;
        }

        // POST api/<ModelProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ModelProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ModelProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
