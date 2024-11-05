using AutoMapper;
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
    public class AddProductsCommandHandler : IRequestHandler<AddProductsCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddProductsCommand> validationRules;
        public AddProductsCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddProductsCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            this.validationRules = validationRules;
        }
        public async Task Handle(AddProductsCommand request, CancellationToken cancellationToken)
        {
            await validationRules.Throw(request);
            var productEntity = _mapper.Map<Product>(request);
            await _uow.ProductRepository.AddAsync(productEntity);
            await _uow.Commit();
        }
    }
}

}
