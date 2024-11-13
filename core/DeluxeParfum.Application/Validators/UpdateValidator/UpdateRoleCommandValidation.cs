using DeluxeParfum.Application.Features.Commands.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.UpdateValidator
{
    public class UpdateRoleCommandValidation : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotNull();

            RuleFor(x => x.RoleName)
                .NotEmpty().WithMessage("Id cannot be empty");
        }
    }
}
