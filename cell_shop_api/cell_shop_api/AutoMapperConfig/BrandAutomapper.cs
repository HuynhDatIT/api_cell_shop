using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class BrandAutomapper : Profile
    {
        public BrandAutomapper()
        {
            CreateMap<GetBrand, Brand>().ReverseMap();
            CreateMap<CreateBrand, Brand>().ReverseMap();
        }
    }
}
