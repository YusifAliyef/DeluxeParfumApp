using DeluxeParfum.Application.Features.Commands.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.AddValidators
{
    internal class AddRoleCommandValidation : AbstractValidator<AddRoleCommand>
    {
        public AddRoleCommandValidation()
        {
            RuleFor(x => x.RoleName)
               .NotEmpty().WithMessage("RoleName cannot be empty");
        }
    }
}
