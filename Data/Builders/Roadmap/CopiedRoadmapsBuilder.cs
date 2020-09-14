using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class CopiedRoadmapsBuilder
    {
        public CopiedRoadmapsBuilder(EntityTypeBuilder<CopiedRoadmaps> builder)
        {
            // fields
            builder.HasKey(copiedRoadmaps => copiedRoadmaps.Id);
            builder.Property(copiedRoadmaps => copiedRoadmaps.Id).ValueGeneratedOnAdd();
            builder.Property(copiedRoadmaps => copiedRoadmaps.SourceRoadmapId).IsRequired();
            builder.Property(copiedRoadmaps => copiedRoadmaps.TargetRoadmapId).IsRequired();

            // relations
            builder.HasOne(copiedRoadmaps => copiedRoadmaps.SourceRoadmap)
                .WithMany(roadmap => roadmap.CopiedSourceRoadmaps)
                .HasForeignKey(copiedRoadmaps => copiedRoadmaps.SourceRoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(copiedRoadmaps => copiedRoadmaps.TargetRoadmap)
                .WithMany(roadmap => roadmap.CopiedTargetRoadmaps)
                .HasForeignKey(copiedRoadmaps => copiedRoadmaps.SourceRoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
