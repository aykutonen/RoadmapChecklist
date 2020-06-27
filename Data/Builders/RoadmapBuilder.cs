using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Data.Builders
{
    public class RoadmapBuilder : BaseEntityBuilder<Roadmap>
    {
        public RoadmapBuilder()
        {
            // fields
            Property(roadmap => roadmap.Name).IsRequired().HasMaxLength(255);
            Property(roadmap => roadmap.Visibility).IsRequired();
            Property(roadmap => roadmap.Status).IsRequired();
            Property(roadmap => roadmap.StartDate).IsRequired();
            Property(roadmap => roadmap.EndDate).IsRequired();
            Property(roadmap => roadmap.UserId).IsRequired();

            // relation
            HasRequired(roadmap => roadmap.User)
                .WithMany(user => user.Roadmaps)
                .HasForeignKey(roadmap => roadmap.UserId)
                .WillCascadeOnDelete(false);

            // table
            ToTable("Roadmap");
        }
    }
}
