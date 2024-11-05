using DeluxeParfum.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Domain.Entities.Accounts
{
    public class Role:EditedBaseEntity
    {
        public Role()
        {
            UserRoles = new HashSet<UserRole>();

        }
        public int Id { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
      

    }
}
