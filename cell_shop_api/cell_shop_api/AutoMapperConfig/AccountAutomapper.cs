using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using Mini_project_API.Helper;

namespace CellShop_Api.AutoMapperConfig
{
    public class AccountAutomapper : Profile
    {
        public AccountAutomapper()
        {
            CreateMap<GetAccount, Account>().ReverseMap();
            CreateMap<CreateAccount, Account>()
                .ForMember(x => x.PassWord, y => y.MapFrom(y => y.PassWord.HashMD5()));
            CreateMap<UpdateAccount, Account>()
                .ForMember(x => x.PassWord, y => y.MapFrom(y => y.PassWord.HashMD5()));
            CreateMap<Register,Account> ()
                .ForMember(x => x.PassWord, y => y.MapFrom(y => y.PassWord.HashMD5()));
            
        }
    }
}
