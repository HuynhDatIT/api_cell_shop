using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class RegisterValidation : AbstractValidator<Register>
    {
        public RegisterValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().Length(2, 100);
            RuleFor(x => x.FullName).NotEmpty().Length(10, 100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PassWord).NotEmpty();
        }
    }
}
