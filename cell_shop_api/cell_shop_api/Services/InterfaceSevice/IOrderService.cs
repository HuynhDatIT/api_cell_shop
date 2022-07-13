using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(CreateOrder createOrder);
        Task<List<GetOrder>> GetOrderByAccountAsync();
        Task<List<GetOrder>> GetAllAsync();
    }
}
