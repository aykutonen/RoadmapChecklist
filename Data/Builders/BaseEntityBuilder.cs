using Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Builders
{
    public class BaseEntityBuilder<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Property(e => e.CreateAt).IsRequired();
            builder.Property(e => e.UpdateAt).IsRequired();
            builder.Property(e => e.Status).IsRequired().HasDefaultValue(1);
        }
    }
}
