using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.BaseRepository
{
    public interface IBaseRepositoryCRUD<T> where T : class
    {
        void Delete(T obj);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T obj);
        void Update(T obj);
    }
}
