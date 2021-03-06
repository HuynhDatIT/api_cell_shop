using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class ProductAutomapper : Profile
    {
        public ProductAutomapper()
        {
            CreateMap<Product, GetProduct>()
                .ForMember(x => x.ModelProductName, 
                           x => x.MapFrom(x => x.ModelProduct.Name));
                
            CreateMap<Product, GetProductId>();

            CreateMap<CreateProduct, Product>().ReverseMap();
            CreateMap<UpdateProduct, Product>().ReverseMap();
        }
    }
}
