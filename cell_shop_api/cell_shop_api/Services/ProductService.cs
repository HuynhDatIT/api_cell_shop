using AutoMapper;
using cell_shop_api.Base.Interface;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
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

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
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

            var getproduct = _mapper.Map<GetProductId>(product);
            getproduct.GetModelProduct = _mapper.Map<GetModelProduct>(product.ModelProduct);
            return getproduct;
        }
    }
}
