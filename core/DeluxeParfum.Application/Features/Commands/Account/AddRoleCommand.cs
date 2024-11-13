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
    public class AddRoleCommand : IMapTo<Role>, IRequest
    {
        public string RoleName { get; set; }
    }
}
