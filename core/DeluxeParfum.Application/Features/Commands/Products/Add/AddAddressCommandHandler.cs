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
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<AddAddressCommand> _validationRules;

        public AddAddressCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<AddAddressCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var addressEntity = _mapper.Map<Address>(request);
            await _uow.AddressRepository.AddAsync(addressEntity);
            await _uow.Commit();
        }
    }
}
