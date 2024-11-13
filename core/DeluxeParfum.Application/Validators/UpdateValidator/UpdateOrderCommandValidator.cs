using DeluxeParfum.Application.Features.Commands.Products.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.UpdateValidator
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .GreaterThan(0);
            RuleFor(x => x.Quantity)
              .NotEmpty();
            RuleFor(x => x.CustomerId)
                .NotEmpty();

        }
    }
}