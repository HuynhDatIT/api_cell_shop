using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateBrandValidation : AbstractValidator<CreateBrand>
    {
        public CreateBrandValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
