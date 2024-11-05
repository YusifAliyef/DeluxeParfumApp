using DeluxeParfum.Application.Features.Commands.Products.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.AddValidators
{
    public class AddProductCommandValidator : AbstractValidator<AddProductsCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product Name cannot be empty");
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description cannot be empty");
            RuleFor(x => x.Weight)
                .NotEmpty();
            RuleFor(x => x.Price)
                .NotNull();
            RuleFor(x => x.CategoryId)
                .NotEmpty();
        }
    }
}

