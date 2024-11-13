using AutoMapper;
using DeluxeParfum.Application.Extensions;
using DeluxeParfum.Application.Interfaces;
using DeluxeParfum.Domain.Entities.Accounts;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Account
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AbstractValidator<AddRoleCommand> _validator;
        public AddRoleCommandHandler(IMapper mapper, AbstractValidator<AddRoleCommand> validator, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _validator = validator;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            await _validator.ThrowIfValidationFailAsync(request);

            var roleEntity = _mapper.Map<Role>(request);
            await _unitOfWork.RoleRepository.AddAsync(roleEntity);
            await _unitOfWork.Commit();
        }
    }
   
}
