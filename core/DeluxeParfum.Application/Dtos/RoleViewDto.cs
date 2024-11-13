using DeluxeParfum.Application.Mappers;
using DeluxeParfum.Domain.Entities.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Application.Dtos
{
    public class RoleViewDto : IMapTo<Role>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
