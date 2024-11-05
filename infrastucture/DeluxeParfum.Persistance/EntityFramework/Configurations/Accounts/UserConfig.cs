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
    public class UserConfig : BaseEntityConfig<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Email)
               .HasMaxLength(25)
               .IsRequired(true)
               .HasColumnName("Email");


            builder.HasIndex(x => x.Email)
                .IsUnique();


            builder.Property(x => x.PasswordHash)
                .HasMaxLength(256)
                .HasColumnName("PasswordHash");


            builder.HasOne(x => x.UserDetail)
                .WithOne(x => x.User)
                .HasForeignKey<UserDetail>(x => x.UserId);


            builder.HasMany(x => x.UserRoles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);


            builder.HasMany(x => x.UploadedFiles)
                .WithOne()
                .HasForeignKey(x => x.UserId);
        }
    }
}
