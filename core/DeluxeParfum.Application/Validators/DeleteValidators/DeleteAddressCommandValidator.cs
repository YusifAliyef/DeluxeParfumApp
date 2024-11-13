using DeluxeParfum.Application.Features.Commands.Products.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.DeleteValidators
{
    public class DeleteAddressCommandValidator:AbstractValidator<DeleteAddressCommand>
    {
        public DeleteAddressCommandValidator()
        {
            RuleFor(x => x.Id)
              .NotNull()
              .GreaterThan(0);
        }
    }
}
