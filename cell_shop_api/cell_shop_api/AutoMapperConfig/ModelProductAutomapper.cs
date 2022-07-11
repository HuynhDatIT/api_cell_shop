using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class ModelProductAutomapper : Profile
    {
        public ModelProductAutomapper()
        {
            CreateMap<ModelProduct, GetModelProduct>()
                .ForMember(x => x.BrandName, x => x.MapFrom(x => x.Brand.Name))
                .ForMember(x => x.CategorieName, x => x.MapFrom(x => x.Categorie.Name))
                .ReverseMap();
                
            CreateMap<CreateModelProduct, ModelProduct>().ReverseMap();
            CreateMap<UpdateModelProduct, ModelProduct>().ReverseMap();
        }
    }
}
