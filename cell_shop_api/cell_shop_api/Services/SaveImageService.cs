using cell_shop_api.Enum;
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
        private bool IsImageSupport(IFormFile file)
        {
            if(Path.GetExtension(file.FileName).ToLower() != ".jpg"
            && Path.GetExtension(file.FileName).ToLower() != ".png"
            && Path.GetExtension(file.FileName).ToLower() != ".gif"
            && Path.GetExtension(file.FileName).ToLower() != ".jpeg")
                return false;
            return true;
        }
        public async Task<string> SaveImageAsync(IFormFile file, TypeImage typeImage)
        {
            if (!IsImageSupport(file)) return null;

            string upload = Path.Combine(_hostingEnvironment.ContentRootPath, $"image//{typeImage}");
            
            if(!Directory.Exists(upload))
                Directory.CreateDirectory(upload);
          
            if (file.Length > 0)
            {
                string filePath = Path.Combine(upload, file.FileName);

                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var path = Path.Combine($"{typeImage}", file.FileName);
                return path;
            }
            return null;
        }
        public async Task<IList<string>> SaveImageRangeAsync(IList<IFormFile> formFiles, TypeImage typeImage)
        {
            string upload = Path.Combine(_hostingEnvironment.ContentRootPath, $"image//{typeImage}");

            if (!Directory.Exists(upload))
                Directory.CreateDirectory(upload);
            
            var listImage = new List<string>();

            foreach (var file in formFiles)
            {
                if (!IsImageSupport(file)) return null;
               
                if (file.Length > 0)
                {
                    string filePath = Path.Combine(upload, file.FileName);

                    using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }

                    listImage.Add(file.FileName);
                }
            }
            
            return listImage;
        }

    }
}
