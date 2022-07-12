using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateModelProductValidation : AbstractValidator<CreateModelProduct>
    {
        public CreateModelProductValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.CategorieId).NotEmpty();
            RuleFor(x => x.Specification).NotEmpty();
            RuleFor(x => x.BrandId).NotEmpty();
        }
    }
}
