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
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<UpdateProductCommand> _validationRules;

        public UpdateProductCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<UpdateProductCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var productDetail = _mapper.Map<Product>(request);

            var editedProductDetail = await _uow.ProductRepository.GetByIdAsync(request.Id);

            editedProductDetail.ProductName = request.ProductName;
            editedProductDetail.Description = request.Description;
            editedProductDetail.Price = request.Price;
            editedProductDetail.CategoryId = request.CategoryId;
            await _uow.Commit();
        }
    }
}
