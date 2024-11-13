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
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {


        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<DeleteOrderCommand> _validationRules;

        public DeleteOrderCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<DeleteOrderCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {

            await _validationRules.ThrowIfValidationFailAsync(request);
            var orderEntity = await _uow.OrderRepository.GetByIdAsync(request.Id);
            if (orderEntity == null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            _uow.OrderRepository.Remove(orderEntity);
            await _uow.Commit();
        }
    }
}
