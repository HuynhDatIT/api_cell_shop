using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateProductValidation : AbstractValidator<CreateProduct>
    {
        public CreateProductValidation()
        {
            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Ram).NotEmpty();
            RuleFor(x => x.Rom).NotEmpty();
            RuleFor(x => x.Stock).NotEmpty();
            RuleFor(x => x.ModelProductId).NotEmpty();
        }
    }
}
