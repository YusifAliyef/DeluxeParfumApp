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
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddCustomerCommand> _validationRules;

        public AddCustomerCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddCustomerCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var customerentity = _mapper.Map<Customer>(request);
            await _uow.CustomerRepository.AddAsync(customerentity);
            await _uow.Commit();
        }
    }
}
