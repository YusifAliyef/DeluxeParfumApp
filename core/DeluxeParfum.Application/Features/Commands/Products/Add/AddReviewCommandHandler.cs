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

namespace DeluxeParfum.Application.Features.Commands.Products.Add
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddReviewCommand> _validationRules;

        public AddReviewCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddReviewCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var productEntity = _mapper.Map<Product>(request);
            await _uow.ProductRepository.AddAsync(productEntity);
            await _uow.Commit();
        }
    }
}
