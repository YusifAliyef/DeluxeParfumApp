using DeluxeParfum.Application.Features.Commands.Products.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.UpdateValidator
{
    internal class UpdateReviewCommandValidaton : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewCommandValidaton()
        {
            RuleFor(x => x.Id)
               .NotNull()
               .GreaterThan(0);
            RuleFor(x => x.ReviewPoint)
              .NotEmpty();
            RuleFor(x => x.Comment)
                .NotEmpty();
            RuleFor(x => x.UserId)
                .NotEmpty();
            RuleFor(x => x.ProductId)
                .NotEmpty();

        }
    }
}