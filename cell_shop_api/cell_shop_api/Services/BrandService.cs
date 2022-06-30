using AutoMapper;
using cell_shop_api.Base.Interface;
using cell_shop_api.Helper;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CellShop_Api.Services
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(CreateBrand createbrand)
        {
            var brand = await _unitOfWork.BrandRepository
                                         .GetBrandByName(createbrand.Name);
            
            if (brand != null)
            {
                return false;
            }
            else
            {
                var brandnew = _mapper.Map<Brand>(createbrand);

                await _unitOfWork.BrandRepository.AddAsync(brandnew);

                return _unitOfWork.SaveChanges() > 0;
            }
            
        }

        public async Task<IEnumerable<GetBrand>> GetAllAsync()
        {
            var listBrand = await _unitOfWork.BrandRepository.GetAllAsync();

            var listGetBrand = _mapper.Map<IEnumerable<GetBrand>>(listBrand);

            return listGetBrand;
        }
        public async Task<GetBrand> GetByIdAsync(int id)
        {
            var brand = await _unitOfWork.BrandRepository.GetByIdAsync(id);

            var getBrand = _mapper.Map<GetBrand>(brand);

            return getBrand;
        }
        public async Task<bool> UpdateAsync(GetBrand getBrand)
        {
            var brand = await _unitOfWork.BrandRepository.GetByIdAsync(getBrand.Id);

            if (brand != null)
            {
                brand.Name = getBrand.Name;

                _unitOfWork.BrandRepository.Update(brand);

                return _unitOfWork.SaveChanges() > 0;
            }
            return false;
        }
    }
}
