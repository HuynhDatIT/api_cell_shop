using cell_shop_api.Base.Interface;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.InheritRepository.Interface
{
    public interface IModelProductRepository : IBaseRepository<ModelProduct>
    {
        Task<ModelProduct> GetModelProductByName (string name);
        Task<IList<ModelProduct>> GetModelProductByCategorie(int categorieId);
    }
}
