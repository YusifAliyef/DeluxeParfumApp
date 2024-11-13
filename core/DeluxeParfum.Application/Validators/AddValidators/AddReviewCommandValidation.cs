using DeluxeParfum.Application.Features.Commands.Products.Add;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Validators.AddValidators
{
    public class AddReviewCommandValidation : AbstractValidator<AddReviewCommand>
    {
        public AddReviewCommandValidation()
        {
            RuleFor(x => x.ReviewPoint)
                .NotEmpty().WithMessage("Review Point Name cannot be empty");
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment cannot be empty");
          
        }
    }
    
}
