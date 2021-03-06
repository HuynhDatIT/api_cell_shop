using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IAddressesService 
    {
        Task<IList<GetAddresse>> GetAddressesByAccountAsync();
        Task<bool> CreateAddresseAsync(CreateAddresse createAddresse);
        Task<bool> UpdateAddresseAsync(UpdateAddresse updateAddresse);
        Task<bool> DeleteAddresseAsync(int id);
        Task<bool> DeleteAddresseRangeAsync(int accountId);
    }
}
