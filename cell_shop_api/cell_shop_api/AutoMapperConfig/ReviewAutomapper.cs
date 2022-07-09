using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class ReviewAutomapper : Profile
    {
        public ReviewAutomapper()
        {
            CreateMap<Review, CreateReview>().ReverseMap();
            CreateMap<Review, UpdateReview>().ReverseMap();
            CreateMap<Review, GetReview>().ReverseMap();
        }
    }
}
