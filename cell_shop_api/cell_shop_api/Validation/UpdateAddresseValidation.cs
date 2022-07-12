using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class UpdateAddresseValidation : AbstractValidator<UpdateAddresse>
    {
        public UpdateAddresseValidation()
        {
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x=>x.Type).NotEmpty();
        }
    }
}
