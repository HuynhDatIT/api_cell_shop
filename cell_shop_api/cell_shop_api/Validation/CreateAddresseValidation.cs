using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateAddresseValidation : AbstractValidator<CreateAddresse>
    {
        public CreateAddresseValidation()
        {
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.TypeAddresse).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
        }
    }
}
