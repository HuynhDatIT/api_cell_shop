using cell_shop_api.Base.Interface;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Repository.Interface
{
    public interface IReviewRepository : IBaseRepository<Review>
    {
        Task<IList<Review>> GetReviewbyProductAsync(int productId);
    }
}
