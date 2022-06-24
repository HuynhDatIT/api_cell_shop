using AutoMapper;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class ProductImageAutomapper : Profile
    {
        public ProductImageAutomapper()
        {
            CreateMap<ProductImage, GetProductImage>().ReverseMap();
        }
    }
}
