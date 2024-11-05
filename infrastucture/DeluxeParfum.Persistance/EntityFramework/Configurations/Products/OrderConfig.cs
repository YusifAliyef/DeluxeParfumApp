using DeluxeParfum.Domain.Entities.Common;
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
    public class OrderConfig:BaseEntityConfig<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Quantity)
                .IsRequired();
            builder.Property(x => x.CommitOrder)
                .IsRequired();
            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId);
            builder.HasMany(x => x.ProductOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
