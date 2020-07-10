using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builder
{
    public class RoadmapBuilder
    {
        public RoadmapBuilder(EntityTypeBuilder<Roadmap> builder)
        {


            builder.HasKey(roadmap => roadmap.Id);
            builder.Property(roadmap => roadmap.Id).ValueGeneratedOnAdd();
            builder.Property(roadmap => roadmap.Name).IsRequired().HasMaxLength(500);
            builder.Property(roadmap => roadmap.Visibility).IsRequired();
            builder.Property(roadmap => roadmap.Status).IsRequired();
            builder.Property(roadmap => roadmap.StartDate).IsRequired();
            builder.Property(roadmap => roadmap.EndDate).IsRequired();
            builder.Property(roadmap => roadmap.UserId).IsRequired();



            builder.HasMany(roadmap => roadmap.CopiedRoadmap)
                .WithOne(CopiedRoadmap => CopiedRoadmap.SourceRoadmap)
                .HasForeignKey(CopiedRoadmap => CopiedRoadmap.SourceRoadmapId)
                .OnDelete(DeleteBehavior.Cascade) 
                .IsRequired();


            builder.HasMany(roadmap => roadmap.CopiedRoadmap)
                .WithOne(CopiedRoadmap => CopiedRoadmap.TargetRoadmap)
                .HasForeignKey(CopiedRoadmap => CopiedRoadmap.TargetRoadmapId)
                .OnDelete(DeleteBehavior.Cascade) 
                .IsRequired();

            builder.HasMany(roadmap => roadmap.RoadmapItem)
                .WithOne(roadmapItems => roadmapItems.Roadmap)
                .HasForeignKey(roadmapItems => roadmapItems.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(roadmap => roadmap.RoadmapCategory)
                .WithOne(roadmapCategories => roadmapCategories.Roadmap)
                .HasForeignKey(roadmapCategories => roadmapCategories.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(roadmap => roadmap.RoadmapTag)
                .WithOne(roadmapTags => roadmapTags.Roadmap)
                .HasForeignKey(roadmapTags => roadmapTags.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();


        }
    }
}
