using DeluxeParfum.Application.Features.Commands.Products.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.AddValidators
{
    public class AddCategoryCommandValidator : AbstractValidator<AddCategoryCommand>
    {
        public AddCategoryCommandValidator()
        {
            RuleFor(x => x.Value)
                .NotNull();
        }
    }
}
