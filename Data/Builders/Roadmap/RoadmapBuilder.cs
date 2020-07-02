using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Data.Builders
{
    public class RoadmapBuilder
    {
        public RoadmapBuilder(EntityTypeBuilder<Roadmap> builder)
        {
            // fields
            builder.HasKey(roadmap => roadmap.Id);
            builder.Property(roadmap => roadmap.Id).ValueGeneratedOnAdd();
            builder.Property(roadmap => roadmap.Name).IsRequired().HasMaxLength(255);
            builder.Property(roadmap => roadmap.Visibility).IsRequired();
            builder.Property(roadmap => roadmap.Status).IsRequired();
            builder.Property(roadmap => roadmap.StartDate).IsRequired();
            builder.Property(roadmap => roadmap.EndDate).IsRequired();
            builder.Property(roadmap => roadmap.UserId).IsRequired();

            // relations
            builder.HasMany(roadmap => roadmap.CopiedRoadmaps)
                .WithOne(copiedRoadmap => copiedRoadmap.Roadmap)
                .HasForeignKey(copiedRoadmap => copiedRoadmap.SourceRoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(roadmap => roadmap.CopiedRoadmaps)
                .WithOne(copiedRoadmap => copiedRoadmap.Roadmap)
                .HasForeignKey(copiedRoadmap => copiedRoadmap.TargetRoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(roadmap => roadmap.RoadmapItems)
                .WithOne(roadmapItems => roadmapItems.Roadmap)
                .HasForeignKey(roadmapItems => roadmapItems.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(roadmap => roadmap.RoadmapCategories)
                .WithOne(roadmapCategories => roadmapCategories.Roadmap)
                .HasForeignKey(roadmapCategories => roadmapCategories.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(roadmap => roadmap.RoadmapTags)
                .WithOne(roadmapTags => roadmapTags.Roadmap)
                .HasForeignKey(roadmapTags => roadmapTags.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
