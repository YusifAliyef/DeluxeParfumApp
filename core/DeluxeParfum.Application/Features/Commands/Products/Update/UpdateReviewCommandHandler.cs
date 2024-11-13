using AutoMapper;
using DeluxeParfum.Application.Extensions;
using DeluxeParfum.Application.Interfaces;
using DeluxeParfum.Domain.Entities.Products;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Products.Update
{
    public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<UpdateReviewCommand> _validationRules;

        public UpdateReviewCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<UpdateReviewCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public  async Task Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var productDetail = _mapper.Map<Review>(request);

            var editedProductDetail = await _uow.ReviewRepository.GetByIdAsync(request.Id);

            editedProductDetail.ReviewPoint = request.ReviewPoint;
            editedProductDetail.Comment = request.Comment;
            editedProductDetail.ProductId = request.ProductId;
            editedProductDetail.UserId = request.UserId;
            await _uow.Commit();
        }
    }
}
