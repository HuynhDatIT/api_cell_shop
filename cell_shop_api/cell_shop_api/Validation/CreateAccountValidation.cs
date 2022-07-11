using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateAccountValidation : AbstractValidator<CreateAccount>
    {
        public CreateAccountValidation()
        {
            RuleFor(x => x.UserName).NotEmpty();
            RuleFor(x => x.PassWord).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.RoleId).NotEmpty();
            RuleFor(x => x.FullName).NotEmpty();
        }
    }
}
