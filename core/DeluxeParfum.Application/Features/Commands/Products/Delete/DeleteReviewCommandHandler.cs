using AutoMapper;
using DeluxeParfum.Application.Extensions;
using DeluxeParfum.Application.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Products.Delete
{
    public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<DeleteReviewCommand> _validationRules;

        public DeleteReviewCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<DeleteReviewCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var reviewEntity = await _uow.ReviewRepository.GetByIdAsync(request.Id);
            if (reviewEntity == null)
            { 
            
                throw new KeyNotFoundException("Review not found");
            }

            _uow.ReviewRepository.Remove(reviewEntity);
            await _uow.Commit();

        }
    }
}
