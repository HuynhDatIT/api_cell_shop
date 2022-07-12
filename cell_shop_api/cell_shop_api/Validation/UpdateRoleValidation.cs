﻿using cell_shop_api.ViewModels.Request;
using FluentValidation;

namespace cell_shop_api.Validation
{
    public class UpdateRoleValidation : AbstractValidator<UpdateRole>
    {
        public UpdateRoleValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
