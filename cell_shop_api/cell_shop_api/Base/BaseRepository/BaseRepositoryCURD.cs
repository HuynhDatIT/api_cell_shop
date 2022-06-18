using CellShop_Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.BaseRepository
{
    public class BaseRepositoryCURD<T> : IBaseRepositoryCRUD<T> where T : class
    {
        private readonly CellShopDbContext _db;

        public BaseRepositoryCURD(CellShopDbContext db)
        {
            _db = db;
        }

        public void Delete(T obj)
        {
            _db.Set<T>().Remove(obj);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var listItem = await _db.Set<T>().ToListAsync();

            return listItem;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var itemT = await _db.Set<T>().FindAsync(id);

            return itemT;
        }

        public async Task AddAsync(T obj)
        {
            await _db.Set<T>().AddAsync(obj);
        }

        public void Update(T obj)
        {
            _db.Set<T>().Update(obj);
        }
    }
}
