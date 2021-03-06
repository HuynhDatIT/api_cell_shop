using AutoMapper;
using cell_shop_api.Base.Interface;
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
        private readonly IClaimsService _claimsService;
        public CartService(IUnitOfWork unitOfWork, IMapper mapper, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
        }


        public async Task<bool> DeleteAsync(int cartid)
        {
            var cart = await _unitOfWork.CartRepository.GetByIdAsync(cartid);

            _unitOfWork.CartRepository.Delete(cart);
           
            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<bool> AddAsync(CreateCart createCart)
        {
            var accountid = _claimsService.GetCurrentAccountId;
            
            var cart = await _unitOfWork.CartRepository
                                        .GetCartByProductAsync(createCart.ProductId, accountid);
            if(cart == null)
            {
                var itemCart = _mapper.Map<Cart>(createCart);

                itemCart.AccountId = accountid;

                await _unitOfWork.CartRepository.AddAsync(itemCart);
                
                return _unitOfWork.SaveChanges() > 0;
            }
            else
            {
                cart.Quantity += createCart.Quantity;
                
                _unitOfWork.CartRepository.Update(cart);
                
                return _unitOfWork.SaveChanges() > 0;
            }
            
        }

        public async Task<IEnumerable<GetCart>> GetCartsAsync()
        {
            var accountid = _claimsService.GetCurrentAccountId;
            
            var carts = await _unitOfWork.CartRepository
                                        .GetCartByAccountIdAsync(accountid);

            var getcart = _mapper.Map<IEnumerable<GetCart>>(carts);
           
            return getcart;
        }

        public async Task<bool> UpdateAsync(UpdateCart updateCart)
        {
            var cart = await _unitOfWork.CartRepository
                                        .GetByIdAsync(updateCart.CartId);
            
            cart.Quantity = updateCart.Quantity;

            if (cart.Quantity <= 0)
                return await DeleteAsync(cart.Id);
            else
            {
                _unitOfWork.CartRepository.Update(cart);
               
                return _unitOfWork.SaveChanges() > 0;
            }

        }

        public async Task<bool> DeleteCartRangeAsync(int accountId)
        {
            var carts = (IList<Cart>)await _unitOfWork.CartRepository
                                                    .GetCartByAccountIdAsync(accountId);
            
            if (carts.Count == 0) return false;

            _unitOfWork.CartRepository.DeleteRange(carts);

            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
