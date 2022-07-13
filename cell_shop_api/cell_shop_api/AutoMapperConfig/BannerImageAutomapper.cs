using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class BannerImageAutomapper:Profile
    {
        public BannerImageAutomapper()
        {  
            CreateMap<CreateBannerImage, BannerImage>().ReverseMap();
            CreateMap<UpdateBannerImage, BannerImage>().ReverseMap();
            CreateMap<GetBannerImage, BannerImage>().ReverseMap();
        }
    }
}
