using DeluxeParfum.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Persistance.EntityFramework.Configurations.Common
{
    public class UploadFiledConfig:EditedBaseEntityConfig<UploadedFile>
    {
        public override void Configure(EntityTypeBuilder<UploadedFile> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.ContentType).HasMaxLength(250);
            builder.Property(x => x.RelativePath).HasMaxLength(250);
            builder.Property(x => x.FileName).HasMaxLength(250);
        }
    }
}
