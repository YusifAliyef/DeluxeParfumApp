using AutoMapper;
using DeluxeParfum.Application.Dtos;
using DeluxeParfum.Application.Helper;
using DeluxeParfum.Application.Interfaces;
using DeluxeParfum.Application.Mappers;
using DeluxeParfum.Domain.Entities.Accounts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Account
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AuthenticatedUserDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IMediator _mediator;

        public CreateUserCommandHandler(IMapper mapper, IUnitOfWork uow, IMediator mediator)
        {
            _mapper = mapper;
            _uow = uow;
            _mediator = mediator;
        }

        public async Task<AuthenticatedUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            var userDetail=_mapper.Map<UserDetail>(request);
            byte[] passwordHash, passwordSalt;

            HashHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);
            user.PasswordHash=Convert.ToBase64String(passwordHash);
            user.PasswordSalt=Convert.ToBase64String(passwordSalt);

            await _uow.UserRepository.AddAsync(user);
            await _uow.Commit();

            return await _mediator.Send(new GenerateTokenCommand
            {
                Email = request.Email,
                Password = request.Password
            });
        }
    }
}
