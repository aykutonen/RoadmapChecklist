using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class RoadmapItemBuilder
    {
        public RoadmapItemBuilder(EntityTypeBuilder<RoadmapItem> builder)
        {
            //fields
            builder.HasKey(roadmapItem => roadmapItem.Id);
            builder.Property(roadmapItem => roadmapItem.Id).ValueGeneratedOnAdd();
            builder.Property(roadmapItem => roadmapItem.Title).IsRequired().HasMaxLength(255);
            builder.Property(roadmapItem => roadmapItem.Description).IsRequired().HasMaxLength(525);
            builder.Property(roadmapItem => roadmapItem.Status).IsRequired();
            builder.Property(roadmapItem => roadmapItem.TargetDate).IsRequired();
            builder.Property(roadmapItem => roadmapItem.EndDate).IsRequired();

            //relations
            builder.HasOne(roadmapItem => roadmapItem.Roadmap)
                .WithMany(roadmap => roadmap.RoadmapItems)
                .HasForeignKey(roadmapItems => roadmapItems.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(roadmapItem => roadmapItem.ChildRoadmapItem)
                .WithOne(roadmapItem => roadmapItem.ParentRoadmapItem)
                .HasForeignKey(roadmapItem => roadmapItem.ParentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
