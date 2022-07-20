using AutoMapper;
using cell_shop_api.Base.Interface;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IClaimsService _claimsService;
        private readonly IProductService _productService;
        private int _accountId;

        public ReviewService(IUnitOfWork unitOfWork, 
                            IMapper mapper,
                            IClaimsService claimsService,
                            IProductService productService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _claimsService = claimsService;
            _productService = productService;
            _accountId = _claimsService.GetCurrentAccountId;
            
        }

        private async Task<bool> IsBuyProduct(int productid)
        {
            var invoicesId = await _unitOfWork.InvoiceRepository.GetInvoiceByAccountAsync(_accountId);

            if(invoicesId == null) return false;

            var invoicesdetail = await _unitOfWork.InvoiceDetailRepository
                                .GetInvoiceDetailsByInvoiceAsync(invoicesId.Select(x => x.Id).ToList());

            var product = invoicesdetail.Where(x => x.ProductId == productid).FirstOrDefault();

            return product != null ? true : false;
        }

        public async Task<bool> CreateReviewAsync(CreateReview createReview)
        {
            if(!await IsBuyProduct(createReview.ProductId)) return false;

            var review = _mapper.Map<Review>(createReview);

            review.AccountId = _accountId;

            await _unitOfWork.ReviewRepository.AddAsync(review);

            var avgRating = await CalculatorRatingAsync(createReview.ProductId);

            var result1 = await _unitOfWork.SaveChangesAsync() > 0;
            
            var result2 = await _productService.UpdateRatingProductAsync(createReview.ProductId, avgRating);

            return  (result1 || result2);
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(reviewId);

            if (review == null) return false;

            review.Status = false;

            _unitOfWork.ReviewRepository.Update(review);
           
            var avgRating = await CalculatorRatingAsync(review.ProductId);

            return await _productService.UpdateRatingProductAsync(review.ProductId, avgRating);
        }

        public async Task<IList<GetReview>> GetAllAsync()
        {
            var reviews = await _unitOfWork.ReviewRepository.GetAllAsync();

            return _mapper.Map<IList<GetReview>>(reviews);
        }

        public async Task<IList<GetReview>> GetReviewByProductAsync(int productId)
        {
            var reviews = await _unitOfWork.ReviewRepository.GetReviewbyProductAsync(productId);

            return _mapper.Map<IList<GetReview>>(reviews);
        }

        public async Task<bool> UpdateReviewAsync(UpdateReview updateReview)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(updateReview.Id);

            if (review == null || review.Id != _accountId) return false;

            var reviewUpdate = _mapper.Map(updateReview, review);

            _unitOfWork.ReviewRepository.Update(review);

            var result1 = await _unitOfWork.SaveChangesAsync() > 0;

            if (updateReview.Rating == review.Rating) return result1;

            var avgRating = await CalculatorRatingAsync(review.ProductId);

            var result2 = await _productService.UpdateRatingProductAsync(review.ProductId, avgRating);

            return (!result1 || !result2);

        }

        private async Task<float> CalculatorRatingAsync(int productId)
        {
            float sum = 0;
            float avg = 0;
            
            var reviews = await _unitOfWork.ReviewRepository.GetReviewbyProductAsync(productId);
            
            if (reviews.Count == 0) return 0;
            
            foreach (var review in reviews)
            {
                sum += review.Rating;
            }
            avg = sum / reviews.Count;
            
            return avg;
        }
    }
}
