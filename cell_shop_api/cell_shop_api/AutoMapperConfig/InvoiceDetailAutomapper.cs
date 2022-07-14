using AutoMapper;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;

namespace cell_shop_api.AutoMapperConfig
{
    public class InvoiceDetailAutomapper : Profile
    {
        public InvoiceDetailAutomapper()
        {
            CreateMap<CreateInvoiceDetail, InvoiceDetail>().ReverseMap();
            CreateMap<GetInvoiceDetail, InvoiceDetail>().ReverseMap();
        }
    }
}
