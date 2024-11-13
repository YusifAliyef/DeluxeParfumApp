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
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AbstractValidator<UpdateAddressCommand> _validationRules;

        public UpdateAddressCommandHandler(IUnitOfWork uow, IMapper mapper, AbstractValidator<UpdateAddressCommand> validationRules)
        {
            _uow = uow;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            await _validationRules.ThrowIfValidationFailAsync(request);
            var addressDetail = _mapper.Map<Address>(request);
            var editedAddresDetail = await _uow.AddressRepository.GetByIdAsync(request.Id);

            editedAddresDetail.CityName = request.CityName;
            editedAddresDetail.Street=request.Street;
            editedAddresDetail.Country=request.Country;

            await _uow.Commit();
        }
    }
}
