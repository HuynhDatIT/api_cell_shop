using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class UpdateAccountValidation : AbstractValidator<UpdateAccount>
    {
        public UpdateAccountValidation()
        {
            RuleFor(x => x.UserName).NotEmpty().Length(2,100);
            RuleFor(x => x.FullName).NotEmpty().Length(5,100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.PassWord).NotEmpty();
        }
    }
}
