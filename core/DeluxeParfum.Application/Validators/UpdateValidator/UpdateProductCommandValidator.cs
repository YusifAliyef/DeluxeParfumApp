using DeluxeParfum.Application.Features.Commands.Products.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.UpdateValidator
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .GreaterThan(0);
            RuleFor(x => x.ProductName)
              .NotEmpty();
            RuleFor(x => x.Description)
                .NotEmpty();
            RuleFor(x => x.Weight)
                .NotEmpty();
            RuleFor(x => x.Price)
                .NotEmpty();
            RuleFor(x => x.CategoryId)
                .NotEmpty();
        }
    }
}
