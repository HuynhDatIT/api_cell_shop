using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class UpdatePromotionValidation : AbstractValidator<UpdatePromotion>
    {
        public UpdatePromotionValidation()
        {
            RuleFor(x => x.Content).NotEmpty();
            RuleFor(x => x.StartDate).NotEmpty();
            RuleFor(x => x.EndDate).NotEmpty();
            RuleFor(x => x.Discount).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
