using AutoMapper;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //public async Task<IEnumerable<GetProductImage>> GetAllAsync()
        //{
        //    var productImages = await _unitOfWork.ProductImageRepository.GetAllAsync();

        //    var getproductImage = _mapper.Map<IEnumerable<GetProductImage>>(productImages);

        //    return getproductImage;    
        //}

        public async Task<IEnumerable<GetProductImage>> GetProductImagesByProductIdAsync(int productId)
        {


            var productImages = await _unitOfWork.ProductImageRepository
                                     .GetProductImageByProductIdAsync(productId);

            var getproductImages = _mapper.Map<IEnumerable<GetProductImage>>(productImages);

            return getproductImages;
        }
    }
}
