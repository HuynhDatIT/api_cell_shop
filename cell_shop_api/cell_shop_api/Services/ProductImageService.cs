using AutoMapper;
using cell_shop_api.Enum;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISaveImageService _saveImageService;

        public ProductImageService(IUnitOfWork unitOfWork, IMapper mapper, ISaveImageService saveImageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _saveImageService = saveImageService;
        }

        public async Task<bool> DeleteProductImageRangeAsync(int productid)
        {
            var productImages = await _unitOfWork.ProductImageRepository
                                            .GetProductImageByProductIdAsync(productid);
            if (productImages == null) return false;
           
            _unitOfWork.ProductImageRepository.DeleteRange(productImages);

            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<IEnumerable<GetProductImage>> GetProductImagesByProductIdAsync(int productId)
        {


            var productImages = await _unitOfWork.ProductImageRepository
                                     .GetProductImageByProductIdAsync(productId);

            var getproductImages = _mapper.Map<IEnumerable<GetProductImage>>(productImages);

            return getproductImages;
        }
        public async Task<bool> UpdateProductImagesByProductIdAsync
                                (UpdateProductImage updateProductImage)
        {
            await DeleteProductImageRangeAsync(updateProductImage.ProductId);

            var paths = await _saveImageService.SaveImageRangeAsync
                                (updateProductImage.formFiles, TypeImage.ImageProduct);
            var productImages = new List<ProductImage>();
            
            foreach (var path in paths)
            {
                var productImage = new ProductImage 
                { ProductId = updateProductImage.ProductId, Path = path };

                productImages.Add(productImage);
            }

            await _unitOfWork.ProductImageRepository.AddRangeAsync(productImages);
           
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
