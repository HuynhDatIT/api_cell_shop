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
        private readonly IProductService _productService;

        public ModelProductService(IUnitOfWork unitOfWork, IMapper mapper, IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<bool> AddAsync(CreateModelProduct createModelProduct)
        {
            var modelProduct = await _unitOfWork.ModelProductRepository
                                    .GetModelProductByName(createModelProduct.Name);

            if (modelProduct != null)
                return false;
            else
            {
                var modelProductNew = _mapper.Map<ModelProduct>(createModelProduct);

                await _unitOfWork.ModelProductRepository.AddAsync(modelProductNew);

                return _unitOfWork.SaveChanges() > 0;
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

        public async Task<IList<GetModelProduct>> GetModelProductbyCategorieAsync(int categorieId)
        {
            var modelProducts = await _unitOfWork.ModelProductRepository
                                    .GetModelProductByCategorie(categorieId);

            var getModelProduct = _mapper.Map<IList<GetModelProduct>>(modelProducts);

            return getModelProduct;
        }

        public async Task<bool> UpdateAsync(UpdateModelProduct updateModelProduct)
        {
            var modelProduct = await _unitOfWork.ModelProductRepository
                                                .GetByIdAsync(updateModelProduct.Id);

            if (modelProduct != null)
            {
                _mapper.Map(updateModelProduct, modelProduct);

                _unitOfWork.ModelProductRepository.Update(modelProduct);

                return _unitOfWork.SaveChanges() > 0;
            }
            return false;
        }
        public async Task<bool> DeleteModelProductAsync(int id)
        {
            var modelProduct = await _unitOfWork.ModelProductRepository
                                                .GetByIdAsync(id);

            if (modelProduct == null) return false;

            modelProduct.Status = false;

            _unitOfWork.ModelProductRepository.Update(modelProduct);
            
            var result = _unitOfWork.SaveChanges() > 0;
            
            var products = await _productService.GetProductByModelIdAsync(id);
            
            if(products != null)
            {
                foreach (var product in products)
                {
                    await _productService.DeleteProductAsync(product.Id);
                }
            }    
            
            return result;  
        }
    }
}
