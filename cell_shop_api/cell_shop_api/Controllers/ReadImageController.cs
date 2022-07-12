using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadImageController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;

        public ReadImageController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("{path}")]
        public IActionResult Get([FromRoute]string path)
        {
            try
            {
                string getimage = Path.Combine(_hostingEnvironment.ContentRootPath, $"image\\{path}");

                Byte[] b = System.IO.File.ReadAllBytes(getimage);

                return File(b, "image/png");
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
