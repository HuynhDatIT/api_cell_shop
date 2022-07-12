using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateReviewValidation : AbstractValidator<CreateReview>
    {
        public CreateReviewValidation()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Rating).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
