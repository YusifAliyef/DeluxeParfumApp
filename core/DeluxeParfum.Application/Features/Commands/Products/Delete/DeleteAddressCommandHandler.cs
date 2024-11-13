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
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly AbstractValidator<DeleteAddressCommand> _validationRules;

        public DeleteAddressCommandHandler(IMapper mapper, IUnitOfWork uow, AbstractValidator<DeleteAddressCommand> validationRules)
        {
            _mapper = mapper;
            _uow = uow;
            _validationRules = validationRules;
        }

        public async Task Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var addressEntity = await _uow.AddressRepository.GetByIdAsync(request.Id);
            if (addressEntity == null)
            {
                throw new KeyNotFoundException("Address not found");
            }
           
            _uow.AddressRepository.Remove(addressEntity);
            await _uow.Commit();
        }
    }
}
