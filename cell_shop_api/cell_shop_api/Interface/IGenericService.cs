using System.Collections.Generic;
using System.Threading.Tasks;

namespace CellShop_Api.Interface
{
    public interface IGenericService<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IList<T>> GetAll();
    }
}
