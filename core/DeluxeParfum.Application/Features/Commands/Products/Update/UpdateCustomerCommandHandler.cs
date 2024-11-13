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
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<UpdateCustomerCommand> _validationRules;

        public UpdateCustomerCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<UpdateCustomerCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);


            var customerDetail = _mapper.Map<Customer>(request);
            var editedCustomerDetail = await _uow.CustomerRepository.GetByIdAsync(request.Id);


            editedCustomerDetail.FirstName = request.FirstName;
            editedCustomerDetail.LastName = request.LastName;
            editedCustomerDetail.PhoneNumber = request.PhoneNumber;
            editedCustomerDetail.AddressId = request.AddressId;
            await _uow.Commit();
        }
    }
}
