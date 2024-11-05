using DeluxeParfum.Domain.Entities.Accounts;
using DeluxeParfum.Persistance.EntityFramework.Configurations.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Persistance.EntityFramework.Configurations.Accounts
{
    public class RoleConfig : EditedBaseEntityConfig<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.RoleName)
             .HasColumnName("RoleName")
             .HasMaxLength(25);


            builder.HasData([
                new Role { Id = 1, RoleName = "Admin", CreatedId = 1, CreateDate = DateTime.UtcNow, UpdatedId = 1, UpdatedDate = DateTime.UtcNow }
                ]);
        }
    }
}
