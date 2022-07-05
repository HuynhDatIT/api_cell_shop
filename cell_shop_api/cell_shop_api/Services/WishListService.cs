using cell_shop_api.Base.Interface;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class WishListService : IWishListService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IClaimsService _claimsService;

        private int accountId;
        public WishListService(IUnitOfWork unitOfWork, IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _claimsService = claimsService;
        }

        public async Task<bool> AddWishListAsync(int productId)
        {
            accountId = _claimsService.GetCurrentAccountId;

            var wishList = await _unitOfWork.WishListRepository
                                       .GetWishListByProductIdAsync(accountId, productId);
            
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);

            if (wishList != null || product == null) return false;

            var wishListNew = new WishList { AccountId = accountId, ProductId = productId };

            await _unitOfWork.WishListRepository.AddAsync(wishListNew);
            
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteWishListAsync(int id)
        {
            var wishList = await _unitOfWork.WishListRepository.GetByIdAsync(id);

            if (wishList == null) return false;

            _unitOfWork.WishListRepository.Delete(wishList);

            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<IList<WishList>> GetWishListAsync()
        {
            accountId = _claimsService.GetCurrentAccountId;
            
            var wishLists = await _unitOfWork.WishListRepository.GetWishListsAsync(accountId);
            
            return wishLists;
        }
    }
}
