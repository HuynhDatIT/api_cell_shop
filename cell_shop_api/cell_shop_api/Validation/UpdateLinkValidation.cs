using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class UpdateLinkValidation : AbstractValidator<UpdateLink>
    {
        public UpdateLinkValidation()
        {
            RuleFor(x => x.PathLink).NotEmpty();
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.Status).NotEmpty();
        }
    }
}
