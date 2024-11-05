using DeluxeParfum.Domain.Entities.Products;
using DeluxeParfum.Persistance.EntityFramework.Configurations.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Persistance.EntityFramework.Configurations.Products
{
    public class CustomerConfig:EditedBaseEntityConfig<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(50);
            builder
             .HasOne(x => x.User)
             .WithOne(x => x.Customer)
             .HasForeignKey<Customer>(x => x.UserId);
        }
    }
}
