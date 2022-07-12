using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class UpdateReviewValidation : AbstractValidator<UpdateReview>
    {
        public UpdateReviewValidation()
        {
            RuleFor(x => x.Rating).NotEmpty();
            RuleFor(x => x.Content).NotEmpty();
        }
    }
}
