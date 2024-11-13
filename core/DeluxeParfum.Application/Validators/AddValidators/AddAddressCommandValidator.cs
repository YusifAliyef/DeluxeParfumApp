using DeluxeParfum.Application.Features.Commands.Products.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.AddValidators
{
    public class AddAddressCommandValidator : AbstractValidator<AddAddressCommand>
    {
        public AddAddressCommandValidator()
        {
            RuleFor(x => x.CityName)
                .NotEmpty().WithMessage("City Name cannot be empty");
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street cannot be empty");
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Country cannot be empty");
        }
    }
}
