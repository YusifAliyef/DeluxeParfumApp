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
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<UpdateOrderCommand> _validationRules;

        public UpdateOrderCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<UpdateOrderCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {

            await _validationRules.ThrowIfValidationFailAsync(request);


            var customerDetail = _mapper.Map<Order>(request);
            var editedCustomerDetail = await _uow.OrderRepository.GetByIdAsync(request.Id);


            editedCustomerDetail.Quantity = request.Quantity;
            editedCustomerDetail.CustomerId = request.CustomerId;
           
            await _uow.Commit();

        }

    }
}
