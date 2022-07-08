using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface ILinkService : IBaseService<GetLink>
    {
        Task<bool> CreateLinkAsync(CreateLink createLink);
        Task<bool> UpdateLinkAsync(UpdateLink updateLink);
        Task<bool> DeleteLinkAsync(int id);
    }
}
