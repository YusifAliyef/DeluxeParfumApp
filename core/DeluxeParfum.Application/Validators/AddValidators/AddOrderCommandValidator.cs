using DeluxeParfum.Application.Features.Commands.Products.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.AddValidators
{
    public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
    {
        public AddOrderCommandValidator()
        {
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage(" Quantity cannot be empty");
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("Customer cannot be empty");

        }
    }
}
