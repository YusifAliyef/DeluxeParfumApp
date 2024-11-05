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
    public class AddressConfig:BaseEntityConfig<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.CityName)
           .IsRequired()
           .HasMaxLength(100);
            builder.Property(x => x.Street)
            .IsRequired()
            .HasMaxLength(200);
            builder.Property(x => x.Country)
            .IsRequired()
            .HasMaxLength(200);

        }
    }
}
