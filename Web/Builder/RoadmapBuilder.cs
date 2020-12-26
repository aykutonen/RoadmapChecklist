using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Db.Entity;

namespace Web.Builder
{
    public class RoadmapBuilder : IEntityTypeConfiguration<Roadmap>
    {

        public virtual void Configure(EntityTypeBuilder<Roadmap> builder)
        {
            builder.HasKey(roadmap => roadmap.Id);
            builder.Property(roadmap => roadmap.Id).ValueGeneratedOnAdd();
            builder.Property(roadmap => roadmap.Name).IsRequired().HasMaxLength(500);
            builder.Property(roadmap => roadmap.Visibility).IsRequired().HasDefaultValue(1);
            builder.Property(roadmap => roadmap.Status).IsRequired().HasDefaultValue(1);

        }
    }
}
