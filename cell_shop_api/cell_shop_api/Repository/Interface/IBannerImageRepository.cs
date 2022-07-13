using cell_shop_api.Base.Interface;
using CellShop_Api.Models;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.Interface
{
    public interface IBannerImageRepository: IBaseRepository<BannerImage>
    {
        public Task<BannerImage> GetBannerImageById(int bannerId);
    }
}
