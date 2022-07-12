using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateOrderValidate : AbstractValidator<CreateOrder>
    {
        public CreateOrderValidate()
        {
            RuleFor(x => x.Total).NotEmpty();
            RuleFor(x => x.DeliveryAddress).NotEmpty();
            RuleFor(x => x.DeliveryPhone).NotEmpty();
            RuleFor(x => x.DeliveryName).NotEmpty();
        }
    }
}
