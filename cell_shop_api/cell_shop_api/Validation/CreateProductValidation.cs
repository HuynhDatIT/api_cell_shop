using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateProductValidation : AbstractValidator<CreateProduct>
    {
        public CreateProductValidation()
        {
        }
    }
}
