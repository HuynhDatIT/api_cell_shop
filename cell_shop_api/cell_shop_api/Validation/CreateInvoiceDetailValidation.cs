using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateInvoiceDetailValidation : AbstractValidator<CreateInvoiceDetail>
    {
        public CreateInvoiceDetailValidation()
        {
            RuleFor(x => x.Price).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
        }
    }
}
