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

        public async Task<bool> Edit(CreateCart createCart)
        {
            //check account...
            var cart = await _unitOfWork.CartRepository
                                           .IsProductAccountExistAsync(createCart);
            if(cart == null)
            {
                if (createCart.Quantity < 0)
                    return false;
                var itemCart = _mapper.Map<Cart>(createCart);
                _unitOfWork.CartRepository.Add(itemCart);
                _unitOfWork.SaveChanges();
                return true;
            }
            else
            {
                cart.Quantity += createCart.Quantity;
                
                if(cart.Quantity == 0)
                {
                    _unitOfWork.CartRepository.Delete(cart);
                    _unitOfWork.SaveChanges();
                    return true;
                }  
                else
                {
                    _unitOfWork.CartRepository.Update(cart);
                    _unitOfWork.SaveChanges();
                    return true;
                }
               
            }
            
        }

        public async Task<IEnumerable<GetCart>> GetCarts(int accountid)
        {
            //check account...
            var carts = await _unitOfWork.CartRepository.GetCartByAccountIdAsync(accountid);

            var getcart = _mapper.Map<IEnumerable<GetCart>>(carts);
           
            return getcart;
        }

    }
}
