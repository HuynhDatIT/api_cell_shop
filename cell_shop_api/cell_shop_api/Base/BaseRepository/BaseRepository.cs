using cell_shop_api.Base.Interface;
using CellShop_Api.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.BaseRepository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseModel
    {
        private readonly CellShopDbContext _db;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(CellShopDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public virtual void Delete(T obj)
        {
            _db.Set<T>().Remove(obj);
        }
        public virtual void DeleteRange(IEnumerable<T> listobj)
        {
            _db.Set<T>().RemoveRange(listobj);
        }
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var listItem = await _dbSet
                                    .Where(x => x.Status == true)
                                        .ToListAsync();

            return listItem;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            var itemT = await _dbSet
                                    .Where(x => x.Status == true && x.Id == id)
                                         .FirstOrDefaultAsync();

            return itemT;
        }

        public virtual async Task AddAsync(T obj)
        {
            await _dbSet.AddAsync(obj);
        }
        public virtual async Task AddRangeAsync(IList<T> listobj)
        {
            await _dbSet.AddRangeAsync(listobj);
        }
        public virtual void Update(T obj)
        {
            _dbSet.Update(obj);
        }
        public virtual void UpdateRange(IList<T> listobj)
        {
            _dbSet.UpdateRange(listobj);
        }

    }
}
