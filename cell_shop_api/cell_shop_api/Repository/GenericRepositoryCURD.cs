using CellShop_Api.Data;
using CellShop_Api.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CellShop_Api.Repository
{
    public class GenericRepositoryCURD<T> : IGenericRepositoryCURD<T> where T : class
    {
        private readonly CellShopDbContext _db;

        public GenericRepositoryCURD(CellShopDbContext db)
        {
            _db = db;
        }

        public void Delete(T obj)
        {
            _db.Set<T>().Remove(obj);
        }

        public async Task<IList<T>> GetAll()
        {
            var listItem = await _db.Set<T>().ToListAsync();
            
            return listItem;
        }

        public async Task<T> GetById(int id)
        {
            var itemT = await _db.Set<T>().FindAsync(id);
            
            return itemT;
        }

        public async Task Insert(T obj)
        {
            await _db.Set<T>().AddAsync(obj);
        }

        public void Update(T obj)
        {
            _db.Set<T>().Update(obj);
        }
    }
}
