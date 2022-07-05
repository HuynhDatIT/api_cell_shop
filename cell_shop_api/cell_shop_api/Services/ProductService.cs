using AutoMapper;
using cell_shop_api.Base.Interface;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISaveImageService _saveImageService;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, ISaveImageService saveImageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _saveImageService = saveImageService;
        }

        public async Task<bool> CreateProductAsync(CreateProduct createProduct)
        {
            var product = _mapper.Map<Product>(createProduct);

            await _unitOfWork.ProductRepository.AddAsync(product);

            var listProductImage = new List<ProductImage>();

            foreach (var imagefile in createProduct.formFiles)
            {
                var path = await _saveImageService.SaveImage(imagefile);

                var productImage = new ProductImage
                {
                    ProductId = product.Id,
                    Path = path
                };
                listProductImage.Add(productImage);
            }
            await _unitOfWork.ProductImageRepository.AddRangeAsync(listProductImage);
           
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<GetProduct>> GetAllAsync()
        {

            var listProduct = await _unitOfWork.ProductRepository.GetAllAsync();

            var listGetProduct = _mapper.Map<IEnumerable<GetProduct>>(listProduct);
           
            return listGetProduct;
        }

        public async Task<GetProductId> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);

            if(product == null) return null;

            var getproduct = _mapper.Map<GetProductId>(product);
            
            getproduct.GetModelProduct = _mapper.Map<GetModelProduct>(product.ModelProduct);
            
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
    }
}
