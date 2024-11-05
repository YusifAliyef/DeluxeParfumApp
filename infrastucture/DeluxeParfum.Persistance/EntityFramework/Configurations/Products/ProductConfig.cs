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
    public class ProductConfig:EditedBaseEntityConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {

            base.Configure(builder);
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price);
            builder.Property(x => x.Weight);


            builder
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId);
            builder.HasMany(x => x.ProductOrders)
                 .WithOne(x => x.Product)
                 .HasForeignKey(x => x.ProductId);

        }
    }
}
