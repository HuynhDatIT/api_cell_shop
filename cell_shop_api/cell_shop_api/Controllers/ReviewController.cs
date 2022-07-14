using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.ViewModels.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Filter;
using System.Threading.Tasks;

namespace cell_shop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetAllProductReview(int productId)
        {
            var reviews = await _reviewService.GetReviewByProductAsync(productId);

            return Ok(reviews);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await _reviewService.GetAllAsync();

            return Ok(reviews);
        }
        [AuthorizeFilterAttribute("admin", "user")]
        [HttpPost]
        public async Task<IActionResult> Add(CreateReview createReview)
        {
            var result = await _reviewService.CreateReviewAsync(createReview);

            return result ? Ok() : BadRequest();
        }
        [AuthorizeFilterAttribute("admin", "user")]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateReview updateReview)
        {
            var result = await _reviewService.UpdateReviewAsync(updateReview);

            return result ? Ok() : BadRequest();
        }
        [AuthorizeFilterAttribute("admin", "user")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reviewService.DeleteReviewAsync(id);

            return result ? Ok() : BadRequest();
        }
    }
}
