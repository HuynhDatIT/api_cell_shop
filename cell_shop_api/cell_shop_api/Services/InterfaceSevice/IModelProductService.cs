using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IModelProductService : IBaseService<GetModelProduct>
    {
        Task<bool> AddAsync (CreateModelProduct createModelProduct);
        Task<bool> UpdateAsync (UpdateModelProduct updateModelProduct);
        Task<IList<GetModelProduct>> GetModelProductbyCategorieAsync(int categorieId);

    }
}
