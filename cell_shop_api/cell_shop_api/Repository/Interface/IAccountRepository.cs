using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Request;
using CellShop_Api.Models;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.Interface
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<Account> GetAccountAsync(string username, string email);
        Task<Account> GetAccountByEmailAsync(string email);
        Task<Account> Login(string username, string password);
    }
}
