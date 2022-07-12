using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreatePromotionValidation : AbstractValidator<CreatePromotion>
    {
        public CreatePromotionValidation()
        {
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();
            RuleFor(x => x.Discount).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
