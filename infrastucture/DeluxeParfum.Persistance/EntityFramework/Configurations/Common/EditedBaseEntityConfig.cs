﻿using DeluxeParfum.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeluxeParfum.Persistance.EntityFramework.Configurations.Common
{
    public class EditedBaseEntityConfig<T> : BaseEntityConfig<T> where T : EditedBaseEntity
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.CreatedId).HasColumnName("CreatedId").IsRequired(false);
            builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
            builder.Property(x => x.UpdatedId).HasColumnName("UpdatedId").IsRequired(false); ;
        }
    }
}
