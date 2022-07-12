using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class UpdateProfileValidation : AbstractValidator<UpdateProfile>
    {
        public UpdateProfileValidation()
        {
            RuleFor(x=>x.FullName).Null().NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
