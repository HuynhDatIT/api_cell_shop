using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class CategoryAutomapper : Profile
    {
        public CategoryAutomapper()
        {
            CreateMap<GetCategorie, Categorie>().ReverseMap();
            CreateMap<CreateCategorie, Categorie>().ReverseMap();
        }
    }
}
