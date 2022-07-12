using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class LoginValidation : AbstractValidator<Login>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Username).NotEmpty().Length(5, 100);
            RuleFor(x => x.Password);
        }
    }
}
