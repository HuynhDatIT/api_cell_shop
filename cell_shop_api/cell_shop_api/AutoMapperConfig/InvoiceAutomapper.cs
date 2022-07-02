using AutoMapper;
using cell_shop_api.ViewModels.Request;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class InvoiceAutomapper : Profile
    {
        public InvoiceAutomapper()
        {
            CreateMap<CreateOrder, Invoice>().ReverseMap();
        }
    }
}
