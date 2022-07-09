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
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private int accountId;

        public ReviewService(IUnitOfWork unitOfWork, 
                            IMapper mapper, 
                            IClaimsService claimsService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;

            accountId = _claimsService.GetCurrentAccountId;
        }

        public async Task<bool> CreateReviewAsync(CreateReview createReview)
        {
            var review = _mapper.Map<Review>(createReview);

            review.AccountId = accountId;

            await _unitOfWork.ReviewRepository.AddAsync(review);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(reviewId);

            if (review == null) return false;

            review.Status = false;

            _unitOfWork.ReviewRepository.Update(review);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<IList<GetReview>> GetReviewByProductAsync(int productId)
        {
            var reviews = await _unitOfWork.ReviewRepository.GetReviewbyProductAsync(productId);

            return _mapper.Map<IList<GetReview>>(reviews);
        }

        public async Task<bool> UpdateReviewAsync(UpdateReview updateReview)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(updateReview.Id);

            if (review == null || review.Id != accountId) return false;

            var reviewUpdate = _mapper.Map(updateReview, review);

            _unitOfWork.ReviewRepository.Update(review);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
    }
}
