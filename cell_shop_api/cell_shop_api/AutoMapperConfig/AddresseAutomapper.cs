using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class AddresseAutomapper : Profile
    {
        public AddresseAutomapper()
        {
            CreateMap<GetAddresse, Addresse>().ReverseMap();
            CreateMap<CreateAddresse, Addresse>().ReverseMap();
            CreateMap<UpdateAddresse, Addresse>().ReverseMap();
        }
    }
}
