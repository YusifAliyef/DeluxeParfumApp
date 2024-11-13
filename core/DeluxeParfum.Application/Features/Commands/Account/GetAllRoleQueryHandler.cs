using AutoMapper;
using DeluxeParfum.Application.Dtos;
using DeluxeParfum.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Features.Commands.Account
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, IEnumerable<RoleViewDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public GetAllRoleQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleViewDto>> Handle(GetAllRoleQuery request, CancellationToken cancellationToken)
        {
            var roles = await _uow.RoleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleViewDto>>(roles);
        }
    }
}

