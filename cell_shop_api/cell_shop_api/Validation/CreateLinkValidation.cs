using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateLinkValidation : AbstractValidator<CreateLink>
    {
        public CreateLinkValidation()
        {
        }
    }
}
