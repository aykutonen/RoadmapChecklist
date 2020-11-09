using System;
using System.Collections.Generic;
using System.Text;
using Data.Builders;
using Entity;
using Entity.Models.Roadmaps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builder
{
    public class RoadmapBuilder:BaseEntityBuilder<Roadmap>
    {
        public override void Configure(EntityTypeBuilder<Roadmap> builder)
        {

            base.Configure(builder);
           
            builder.Property(roadmap => roadmap.Id).ValueGeneratedOnAdd();
            builder.Property(roadmap => roadmap.Name).IsRequired().HasMaxLength(500);
            builder.Property(roadmap => roadmap.Visibility).IsRequired().HasDefaultValue(1);

            builder.HasOne(roadmap => roadmap.Source)
                .WithOne(CopiedRoadmap => CopiedRoadmap.SourceRoadmap)
                .HasForeignKey<CopiedRoadmap>(roadmap => roadmap.SourceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(roadmap => roadmap.Targets)
                .WithOne(CopiedRoadmap => CopiedRoadmap.TargetRoadmap)
                .HasForeignKey(CopiedRoadmap => CopiedRoadmap.TargetId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(roadmap => roadmap.RoadmapItems)
                .WithOne(roadmapItems => roadmapItems.Roadmap)
                .HasForeignKey(roadmapItems => roadmapItems.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(roadmap => roadmap.RoadmapCategories)
                .WithOne(roadmapCategories => roadmapCategories.Roadmap)
                .HasForeignKey(roadmapCategories => roadmapCategories.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasMany(roadmap => roadmap.RoadmapTags)
                .WithOne(Tag => Tag.Roadmap)
                .HasForeignKey(Tag => Tag.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
