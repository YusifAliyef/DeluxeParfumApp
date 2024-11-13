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
    public class UpdateRoleCommand : IMapTo<Role>, IRequest
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
    
    
}
