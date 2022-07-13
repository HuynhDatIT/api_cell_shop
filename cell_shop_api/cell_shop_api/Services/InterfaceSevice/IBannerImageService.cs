using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IBannerImageService
    {
        Task<IEnumerable<GetBannerImage>> GetAllBannerImageAsync();
        Task<bool> CreateBannerImageAnsyc(CreateBannerImage createBannerImage);
        Task<bool> UpdateBannerImageAnsyc(UpdateBannerImage createBannerImage);
        Task<bool> DelteBannerImageAnsyc(int bannerId);
    }
}
