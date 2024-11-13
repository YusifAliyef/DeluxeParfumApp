using DeluxeParfum.Application.Features.Commands.Products.Delete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.DeleteValidators
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotNull();
        }
    }
}
