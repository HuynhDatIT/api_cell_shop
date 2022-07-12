using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class UpdateModelProductValidation : AbstractValidator<UpdateModelProduct>
    {
        public UpdateModelProductValidation()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3).MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.CategorieId).NotEmpty();
            RuleFor(x => x.Specification).NotEmpty();
            RuleFor(x => x.BrandId).NotEmpty();
        }
    }
}
