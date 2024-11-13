using DeluxeParfum.Application.Mappers;
using DeluxeParfum.Domain.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Dtos
{
    public class AuthenticatedUserDto:IMapTo<User>
    {
        public string Token { get; set; }
    }
}
