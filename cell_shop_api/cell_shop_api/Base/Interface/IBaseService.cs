using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Base.Interface
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
    }
}
