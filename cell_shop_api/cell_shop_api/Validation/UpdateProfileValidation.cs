using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class UpdateProfileValidation : AbstractValidator<UpdateProfile>
    {
        public UpdateProfileValidation()
        {
            RuleFor(x=>x.FullName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Birthday).Null();

        }
    }
}
