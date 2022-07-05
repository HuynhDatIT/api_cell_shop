using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class RoleAutomapper : Profile
    {
        public RoleAutomapper()
        {
            CreateMap<GetRole, Role>().ReverseMap();
            CreateMap<UpdateRole, Role>().ReverseMap();
        }
    }
}
