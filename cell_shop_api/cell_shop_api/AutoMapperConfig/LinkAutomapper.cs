using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class LinkAutomapper : Profile
    {
        public LinkAutomapper()
        {
            CreateMap<GetLink, Link>().ReverseMap();
            CreateMap<CreateLink, Link>().ReverseMap();
            CreateMap<UpdateLink, Link>().ReverseMap();
        }
    }
}
