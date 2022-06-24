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

        public int Add(CreateBrand createbrand)
        {
            var isExist = _unitOfWork.BrandRepository.IsNameExist(createbrand.Name);
            
            if (isExist)
            {
                return 0;
            }
            else
            {
                var brand = _mapper.Map<Brand>(createbrand);

                _unitOfWork.BrandRepository.Add(brand);

                return _unitOfWork.SaveChanges();
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

        public async Task<int> Update(GetBrand getBrand)
        {
            var brand = await _unitOfWork.BrandRepository.GetByIdAsync(getBrand.Id);

            if (brand != null)
            {
                brand.Name = getBrand.Name;

                _unitOfWork.BrandRepository.Update(brand);

                return _unitOfWork.SaveChanges();
            }
            return 0;
        }

    }
}
