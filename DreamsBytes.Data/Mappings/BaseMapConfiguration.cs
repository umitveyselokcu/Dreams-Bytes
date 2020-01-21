using DreamsBytes.Core;
using DreamsBytes.Core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DreamsBytes.Data.Mappings
{
    public class BaseMapConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            string  tableName = builder.Metadata.ClrType.Name;            
            builder.ToTable(tableName);
            builder.HasKey(entity => entity.Id);
            builder.Property(entity => entity.CreatedOnUtc).HasDefaultValueSql("getdate()");

        }

    }
}
