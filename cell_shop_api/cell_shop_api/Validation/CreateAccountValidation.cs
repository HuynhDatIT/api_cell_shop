using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateAccountValidation : AbstractValidator<CreateAccount>
    {
        public CreateAccountValidation()
        {
            
        }
    }
}
