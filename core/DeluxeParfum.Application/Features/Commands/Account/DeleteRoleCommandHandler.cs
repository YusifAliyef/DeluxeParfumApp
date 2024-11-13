using DeluxeParfum.Application.Exception;
using DeluxeParfum.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Account
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRoleCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(request.Id);
            if (role is null)
            {
                throw new DeluxeParfumValidationException("Id not found");
            }

            _unitOfWork.RoleRepository.Remove(role);

            await _unitOfWork.Commit();
        }
    }
}

