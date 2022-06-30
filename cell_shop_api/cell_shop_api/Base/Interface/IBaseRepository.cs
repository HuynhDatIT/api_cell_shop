using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Base.Interface
{
    public interface IBaseRepository<T> where T : class
    {
        void Delete(T obj);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T obj);
        void Update(T obj);
    }
}
