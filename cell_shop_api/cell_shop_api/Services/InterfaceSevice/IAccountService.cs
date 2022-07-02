using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IAccountService : IBaseService<GetAccount>
    {
       
        Task<bool> AddAsync(CreateAccount createAccount);
        Task<bool> UpdateAsync(UpdateAccount updateAccount);
        Task<bool> DeleteAsync(int id);
       
    }
}
