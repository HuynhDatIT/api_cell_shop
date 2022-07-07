using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface ISaveImageService
    {
        Task<string> SaveImageAsync(IFormFile formfile);
        Task<IList<string>> SaveImageRangeAsync(IList<IFormFile> formFiles);
    }
}
