using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface ISaveImageService
    {
        Task<string> SaveImage(IFormFile formFiles);
    }
}
