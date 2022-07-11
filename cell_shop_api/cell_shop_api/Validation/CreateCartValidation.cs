using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateCartValidation : AbstractValidator<CreateCart>
    {
        public CreateCartValidation()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty().GreaterThan(0);
        }
    }
}
