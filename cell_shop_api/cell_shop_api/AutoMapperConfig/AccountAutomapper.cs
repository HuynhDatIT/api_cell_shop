using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace CellShop_Api.AutoMapperConfig
{
    public class AccountAutomapper : Profile
    {
        public AccountAutomapper()
        {
            CreateMap<GetAccount, Account>().ReverseMap();
            CreateMap<CreateAccount, Account>().ReverseMap();
            CreateMap<UpdateAccount, Account>().ReverseMap();
        }
    }
}
