using AutoMapper;
using CellShop_Api.Models;
using CellShop_Api.ViewModels;

namespace CellShop_Api.AutoMapperConfig
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Categorie, CategorieViewModel>()
                .ForMember(cvm => cvm.Id, c => c.MapFrom(c => c.Id))
                .ForMember(cvm => cvm.Name, c => c.MapFrom(c => c.Name));

            CreateMap<CategorieViewModel, Categorie>()
                 .ForMember(c => c.Name, cvm => cvm.MapFrom(cvm => cvm.Name));


            CreateMap<Brand, BrandViewModel>()
                .ForMember(bvm => bvm.Id, b => b.MapFrom(b => b.Id))
                .ForMember(bvm => bvm.Name, b => b.MapFrom(b => b.Name));

            CreateMap<BrandViewModel, Brand>()
                .ForMember(b => b.Name, bvm => bvm.MapFrom(bvm => bvm.Name));


            CreateMap<ModelProduct, ModelProductViewModel>()
                .ForMember(mpvm => mpvm.Id, mp => mp.MapFrom(mp => mp.Id))
                .ForMember(mpvm => mpvm.Name, mp => mp.MapFrom(mp => mp.Name))
                .ForMember(mpvm => mpvm.BrandId, mp => mp.MapFrom(mp => mp.Brand.Id))
                .ForMember(mpvm => mpvm.CategorieId, mp => mp.MapFrom(mp => mp.Categorie.Id))
                .ForMember(mpvm => mpvm.Specification, mp => mp.MapFrom(mp => mp.Specification))
                .ForMember(mpvm => mpvm.Description, mp => mp.MapFrom(mp => mp.Description));

            //CreateMap<ModelProductViewModel, ModelProduct>()
            //    .ForMember(mp => mp.Name, mpvm => mpvm.MapFrom(mpvm => mpvm.Name))
            //    .ForMember(mp => mp.Brand.Id, mpvm => mpvm.MapFrom(mpvm => mpvm.BrandId))
            //    .ForMember(mp => mp.Categorie.Id, mpvm => mpvm.MapFrom(mpvm => mpvm.CategorieId))
            //    .ForMember(mp => mp.Specification, mpvm => mpvm.MapFrom(mpvm => mpvm.Specification))
            //    .ForMember(mp => mp.Description, mpvm => mpvm.MapFrom(mpvm => mpvm.Description));
        }
    }
}
