using DeluxeParfum.Application.Features.Commands.Products.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.UpdateValidator
{
    public class UpdateAddressCommandValidator:AbstractValidator<UpdateAddressCommand>
    {
        public UpdateAddressCommandValidator() 
        {
            RuleFor(x => x.Id)
              .NotNull()
              .GreaterThan(0);
            RuleFor(x => x.CityName)
              .NotEmpty();
            RuleFor(x => x.Street)
                .NotEmpty();
            RuleFor(x => x.Country)
                .NotEmpty();
        }
    }
}
