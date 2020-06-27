using Entity.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace Data.Builders
{
    public abstract class BaseEntityBuilder<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        protected BaseEntityBuilder()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity); // auto-increment
        }
    }
}
