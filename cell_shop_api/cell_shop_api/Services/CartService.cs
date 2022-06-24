using AutoMapper;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public string Add(CreateCart createCart)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<GetCart>> GetCarts(int accountid)
        {
            var carts = await _unitOfWork.CartRepository.GetCartByAccountIdAsync(accountid);

            var getcart = _mapper.Map<IEnumerable<GetCart>>(carts);
           
            return getcart;
        }
    }
}
