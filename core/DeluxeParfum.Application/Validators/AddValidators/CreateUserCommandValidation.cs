using DeluxeParfum.Application.Extensions;
using DeluxeParfum.Application.Features.Commands.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.AddValidators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Email)
                    .NotEmpty()
                    .CheckNull();

            RuleFor(x => x.FirstName)
                     .NotEmpty()
                     .CheckNull();

            RuleFor(x => x.LastName)
                     .NotEmpty()
                     .CheckNull();


            RuleFor(x => x.Password)
                     .NotEmpty()
                     .CheckNull();
        }
    }
}
