using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Entity.Models;

namespace Data.Builders
{
    public class BaseEntityBuilder<T> : IEntityTypeConfiguration<T> where T : ModelBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {

            builder.HasKey(Entity=>Entity.Id);
            builder.Property(Entity =>Entity).ValueGeneratedOnAdd();
            builder.Property(Entity=> Entity.CreateAt).IsRequired();
            builder.Property(Entity => Entity.UpdateAt).IsRequired();
            builder.Property(Entity=> Entity.Status).IsRequired().HasDefaultValue(1);
        }
    }
}
