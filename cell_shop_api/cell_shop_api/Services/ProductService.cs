using AutoMapper;
using cell_shop_api.Base.Interface;
using cell_shop_api.Enum;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISaveImageService _saveImageService;
        private readonly IProductImageService _productImageService;

        public ProductService(IUnitOfWork unitOfWork, 
                                IMapper mapper,
                                ISaveImageService saveImageService,
                                IProductImageService productImageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _saveImageService = saveImageService;
            _productImageService = productImageService;
        }

        public async Task<bool> CreateProductAsync(CreateProduct createProduct)
        {
            var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var product = _mapper.Map<Product>(createProduct);

                await _unitOfWork.ProductRepository.AddAsync(product);

                await _unitOfWork.SaveChangesAsync();

                var listProductImage = new List<ProductImage>();

                foreach (var imagefile in createProduct.formFiles)
                {
                    var path = await _saveImageService.SaveImageAsync
                                    (imagefile, TypeImage.ImageProduct);

                    var productImage = new ProductImage
                    {
                        ProductId = product.Id,
                        Path = path
                    };
                    listProductImage.Add(productImage);
                }
                await _unitOfWork.ProductImageRepository.AddRangeAsync(listProductImage);

                await _unitOfWork.SaveChangesAsync();
               
                await transaction.CommitAsync();

                return true;
            }
            catch (System.Exception)
            {
                transaction.Rollback();
                throw;
            }
            
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var trancistion = await _unitOfWork.BeginTransactionAsync();
            
            try
            {
                var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

                if (product == null) return false;

                product.Status = false;

                _unitOfWork.ProductRepository.Update(product);

                _unitOfWork.SaveChanges();

                await _productImageService.DeleteProductImageRangeAsync(id);

                var carts = await _unitOfWork.CartRepository.GetCartByProductIdAsync(id);

                _unitOfWork.CartRepository.DeleteRange(carts);

                _unitOfWork.SaveChanges();

                await trancistion.CommitAsync();

                return true;
            }
            catch (System.Exception)
            {
                trancistion.Rollback();
                throw;
            }
            
        }

        public async Task<IEnumerable<GetProduct>> GetAllAsync()
        {

            var listProduct = await _unitOfWork.ProductRepository.GetAllAsync();

            var listGetProduct = _mapper.Map<IEnumerable<GetProduct>>(listProduct);
           
            return listGetProduct;
        }

        public async Task<GetProduct> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if(product == null) return null;

            var getproduct = _mapper.Map<GetProduct>(product);
            
            return getproduct;
        }

        public async Task<IList<GetProduct>> GetProductByModelIdAsync(int modelId)
        {
            var model = await _unitOfWork.ModelProductRepository.GetByIdAsync(modelId);

            if(model == null) return null;  

            var listProduct = await _unitOfWork.ProductRepository
                                                .GetProductByModelIdAsync(modelId);

            var listGetProduct = _mapper.Map<IList<GetProduct>>(listProduct);

            return listGetProduct;
        }

        public async Task<IList<GetProduct>> GetProductsByCatagorieAsync(int categorieId)
        {
            var categorie = await _unitOfWork.CategorieRepository.GetByIdAsync(categorieId);

            if (categorie == null) return null;

            var listProduct = await _unitOfWork.ProductRepository
                                                .GetProductsByCatagorieAsync(categorieId);

            var listGetProduct = _mapper.Map<IList<GetProduct>>(listProduct);

            return listGetProduct;
        }

        public async Task<bool> UpdateProductAsync(UpdateProduct updateProduct)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(updateProduct.Id);

            if (product == null) return false;

            var productNew = _mapper.Map(updateProduct, product);

            _unitOfWork.ProductRepository.Update(productNew);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateRatingProductAsync(int productId, float avgRating)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);

            if (product == null) return false;

            product.Rating = avgRating;

            _unitOfWork.ProductRepository.Update(product);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        public async Task<IList<GetProduct>> SearchProductAsync(int? categorieId, int? brandId, string? name)
        {
            
            var products = await _unitOfWork.ProductRepository.GetAllAsync();

            if(categorieId != null)
                products = products.Where(x => x.ModelProduct.CategorieId == categorieId).ToList();
            if(brandId != null)
                products = products.Where(x => x.ModelProduct.BrandId == brandId).ToList();
            if (name != null)
                products = products.Where(x => x.ModelProduct.Name.ToLower().Contains(name.ToLower())).ToList();

            return _mapper.Map<IList<GetProduct>>(products);
        }
    }
}
