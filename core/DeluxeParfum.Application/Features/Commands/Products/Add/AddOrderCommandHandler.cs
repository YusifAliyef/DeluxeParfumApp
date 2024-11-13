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
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddOrderCommand> _validationRules;

        public AddOrderCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddOrderCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var orderentity = _mapper.Map<Order>(request);
            await _uow.OrderRepository.AddAsync(orderentity);
            await _uow.Commit();
        }
    }
}
