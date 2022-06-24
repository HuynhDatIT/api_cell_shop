using cell_shop_api.Base.Interface;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IModelProductService : IBaseService<GetModelProduct>
    {
        int Add(CreateModelProduct createModelProduct);
        Task<int> Update(UpdateModelProduct updateModelProduct);
    }
}
