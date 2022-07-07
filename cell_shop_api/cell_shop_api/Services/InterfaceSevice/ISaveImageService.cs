using cell_shop_api.Enum;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface ISaveImageService
    {
        Task<string> SaveImageAsync(IFormFile formfile, TypeImage typeImage);
        Task<IList<string>> SaveImageRangeAsync(IList<IFormFile> formFiles, TypeImage typeImage);
    }
}
