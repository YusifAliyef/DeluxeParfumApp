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
    public class ReviewConfig:BaseEntityConfig<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Comment)
                .IsRequired()
                .HasMaxLength(250);
            builder.Property(x => x.ReviewPoint)
                .IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Product)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ProductId);

        }
    }
}
