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
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<int> DeleteAsync(int cartid)
        {
            var cart = await _unitOfWork.CartRepository.GetByIdAsync(cartid);

            _unitOfWork.CartRepository.Delete(cart);
           
            return _unitOfWork.SaveChanges();
        }

        public async Task<int> AddAsync(CreateCart createCart)
        {
            var cart = await _unitOfWork.CartRepository
                                           .IsProductAccountExistAsync(createCart);
            if(cart == null)
            {
                var itemCart = _mapper.Map<Cart>(createCart);
                _unitOfWork.CartRepository.Add(itemCart);
                return _unitOfWork.SaveChanges();
                
            }
            else
            {
                cart.Quantity += createCart.Quantity;
                _unitOfWork.CartRepository.Update(cart);
                return _unitOfWork.SaveChanges();
            }
            
        }

        public async Task<IEnumerable<GetCart>> GetCartsAsync(int accountid)
        {
            //check account...
            var carts = await _unitOfWork.CartRepository.GetCartByAccountIdAsync(accountid);

            var getcart = _mapper.Map<IEnumerable<GetCart>>(carts);
           
            return getcart;
        }

        public async Task<int> UpdateAsync(UpdateCart updateCart)
        {
            var cart = await _unitOfWork.CartRepository.GetByIdAsync(updateCart.CartId);
            
            cart.Quantity = updateCart.Quantity;
            
            _unitOfWork.CartRepository.Update(cart);
            
            return _unitOfWork.SaveChanges();
        }
    }
}
