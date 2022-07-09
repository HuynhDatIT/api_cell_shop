using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services.InterfaceSevice
{
    public interface IReviewService
    {
        Task<bool> CreateReviewAsync(CreateReview createReview);
        Task<bool> DeleteReviewAsync(int reviewId);
        Task<bool> UpdateReviewAsync(UpdateReview updateReview);
        Task<IList<GetReview>> GetReviewByProductAsync(int productId);
    }
}
