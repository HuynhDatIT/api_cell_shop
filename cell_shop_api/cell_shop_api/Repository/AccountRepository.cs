using cell_shop_api.Repository.BaseRepository;
using cell_shop_api.Repository.Interface;
using cell_shop_api.ViewModels.Request;
using CellShop_Api.Data;
using CellShop_Api.Models;
using Microsoft.EntityFrameworkCore;
using Mini_project_API.Helper;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Repository
{
    public class AccountRepository : BaseRepositoryCURD<Account>, IAccountRepository
    {
        public AccountRepository(CellShopDbContext db) : base(db)
        {
        }

        public async Task<Account> GetAccountAsync(string username, string email)
        {
            return await _dbSet.Where(x => x.Status == true)
                               .FirstOrDefaultAsync
                                (x => x.UserName == username || x.Email == email);
        }
        public async Task<Account> GetAccountByEmailAsync(string email)
        {
            return await _dbSet.Where(x => x.Status == true)
                               .FirstOrDefaultAsync
                                (x => x.Email == email);
        }

        public async Task<Account> Login(string username, string password)
        {
            return await _dbSet.Include(x => x.Role)
                                .Where(x => x.Status == true)
                                .FirstOrDefaultAsync
                                 (x => x.UserName == username && x.PassWord == password.HashMD5());
        }
    }
}
