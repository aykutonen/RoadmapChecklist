using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class RoadmapTagBuilder
    {
        public RoadmapTagBuilder(EntityTypeBuilder<RoadmapTagRelation> builder)
        {
            //fields
            builder.HasKey(roadmapTag => roadmapTag.Id);
            builder.Property(roadmapTag => roadmapTag.Id).ValueGeneratedOnAdd();
            builder.Property(roadmapTag => roadmapTag.TagId).IsRequired();
            builder.Property(roadmapTag => roadmapTag.RoadmapId).IsRequired();

            //relations
            builder.HasOne(roadmapTag => roadmapTag.Tag)
                .WithMany(tag => tag.RoadmapTags)
                .HasForeignKey(roadmapTag => roadmapTag.TagId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(roadmapTag => roadmapTag.Roadmap)
                .WithMany(roadmap => roadmap.RoadmapTags)
                .HasForeignKey(roadmapTag => roadmapTag.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
