using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IPromotionService : IBaseService<GetPromotion>
    {
        Task<bool> CreateLinkAsync(CreatePromotion createPromotion);
        Task<bool> UpdateLinkAsync(UpdatePromotion updatePromotion);
        Task<bool> DeleteLinkAsync(int id);
    }
}
