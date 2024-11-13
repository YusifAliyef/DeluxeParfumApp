using DeluxeParfum.Application.Features.Commands.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.DeleteValidators
{
    internal class DeleteRoleCommandValidation : AbstractValidator<DeleteRoleCommand>
    {
        public DeleteRoleCommandValidation()
        {
            RuleFor(x => x.Id)
                .NotNull();
        }
    }
}
