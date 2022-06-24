using AutoMapper;
using cell_shop_api.Helper;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class ModelProductService : IModelProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ModelProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public int Add(CreateModelProduct createModelProduct)
        {
            var isExist = _unitOfWork.ModelProductRepository.IsNameExist(createModelProduct.Name);

            if (isExist)
                return 0;
            else
            {
                var modelProduct = _mapper.Map<ModelProduct>(createModelProduct);

                _unitOfWork.ModelProductRepository.Add(modelProduct);

                return _unitOfWork.SaveChanges();
            }
        }

        public async Task<IEnumerable<GetModelProduct>> GetAllAsync()
        {
            var listModelProduct = await _unitOfWork.ModelProductRepository.GetAllAsync(); 

            var listGetModelProduct = _mapper.Map<IEnumerable<GetModelProduct>>(listModelProduct);

            return listGetModelProduct;
        }

        public async Task<GetModelProduct> GetByIdAsync(int id)
        {
            var modelProduct = await _unitOfWork.ModelProductRepository.GetByIdAsync(id);

            var getModelProduct = _mapper.Map<GetModelProduct>(modelProduct);

            return getModelProduct;
        }

        public async Task<int> Update(UpdateModelProduct updateModelProduct)
        {
            var modelProduct = await _unitOfWork.ModelProductRepository.GetByIdAsync(updateModelProduct.Id);

            if (modelProduct != null)
            {
                modelProduct.Name = updateModelProduct.Name;
                modelProduct.Description = updateModelProduct.Description;
                modelProduct.Specification = updateModelProduct.Specification;
                modelProduct.CategorieId = updateModelProduct.CategorieId;
                modelProduct.BrandId = updateModelProduct.BrandId;

                _unitOfWork.ModelProductRepository.Update(modelProduct);

                return _unitOfWork.SaveChanges();
            }
            return 0;
        }
    }
}
