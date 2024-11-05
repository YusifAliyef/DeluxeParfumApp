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
    public class CardItemConfig:BaseEntityConfig<CardItem>
    {
        public void Configure(EntityTypeBuilder<CardItem> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Quantity)
           .IsRequired();
            builder.HasOne(x => x.Product)
                .WithMany(x => x.CardItems)
                .HasForeignKey(x => x.ProductId);

        }
    }
}
