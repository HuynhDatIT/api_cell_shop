using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class UpdateCartValidation : AbstractValidator<UpdateCart>
    {
        public UpdateCartValidation()
        {
            RuleFor(x => x.CartId).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
        }
    }
}
