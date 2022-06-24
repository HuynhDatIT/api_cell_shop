using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class CartAutomapper : AutoMapper.Profile
    {
        public CartAutomapper()
        {
            CreateMap<Cart, GetCart>().ReverseMap();
                
        }

    }
}
