using DeluxeParfum.Application.Features.Commands.Products.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.AddValidators
{
    partial class AddCustomerCommandValidation : AbstractValidator<AddCustomerCommand>
    {
        public AddCustomerCommandValidation()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(" FirstName cannot be empty");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty");
            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("PhoneNumber cannot be empty");
            RuleFor(x => x.AddressId)
                .NotEmpty();
        }
    }
    
}
