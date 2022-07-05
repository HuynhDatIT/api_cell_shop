using cell_shop_api.Services.InterfaceSevice;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class SaveImageService : ISaveImageService
    {
        private IWebHostEnvironment _hostingEnvironment;

        public SaveImageService(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> SaveImage(IFormFile file)
        {
            
            string upload = Path.Combine(_hostingEnvironment.ContentRootPath, "image");
            
            if(!Directory.Exists(upload))
                Directory.CreateDirectory(upload);
          
            if (file.Length > 0)
            {
                string filePath = Path.Combine(upload, file.FileName);

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return file.FileName;
            }
            return null;
        }
      
    }
}
