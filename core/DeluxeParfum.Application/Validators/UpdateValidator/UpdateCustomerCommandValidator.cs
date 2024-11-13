using DeluxeParfum.Application.Features.Commands.Products.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.UpdateValidator
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .GreaterThan(0);
            RuleFor(x => x.FirstName)
              .NotEmpty();
            RuleFor(x => x.LastName)
                .NotEmpty();
            RuleFor(x => x.PhoneNumber)
                .NotEmpty();
            RuleFor(x => x.AddressId)
                .NotEmpty();
           
        }
    }
}
