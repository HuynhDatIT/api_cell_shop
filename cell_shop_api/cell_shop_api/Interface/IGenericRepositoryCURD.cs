using System.Collections.Generic;
using System.Threading.Tasks;

namespace CellShop_Api.Interface
{
    public interface IGenericRepositoryCURD<T> where T : class
    {
        Task<IList<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
