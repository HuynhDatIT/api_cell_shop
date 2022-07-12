using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class CreateLinkValidation : AbstractValidator<CreateLink>
    {
        public CreateLinkValidation()
        {
            RuleFor(x => x.PathLink).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
        }
    }
}
