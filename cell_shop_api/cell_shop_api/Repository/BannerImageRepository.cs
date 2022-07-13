using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.Interface;
using CellShop_Api.Data;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Repository
{
    public class BannerImageRepository:BaseRepository<BannerImage>,IBannerImageRepository
    {
        public BannerImageRepository(CellShopDbContext db) : base(db)
        {
        }

        public async Task<BannerImage> GetBannerImageById(int bannerId)
        {
            var bannerImage = await _dbSet.Where(x => x.Id == bannerId && x.IsActive == true).FirstOrDefaultAsync();
            return bannerImage;
        }
    }
}
