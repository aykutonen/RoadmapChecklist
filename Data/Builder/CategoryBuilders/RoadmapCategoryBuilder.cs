using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builder
{
    public class RoadmapCategoryBuilder
    {
        public RoadmapCategoryBuilder(EntityTypeBuilder<RoadmapCategory> builder)
        {
            //fields
            builder.HasKey(roadmapCategory => roadmapCategory.Id);
            builder.Property(roadmapCategory => roadmapCategory.Id).ValueGeneratedOnAdd();
            builder.Property(roadmapCategory => roadmapCategory.CategoryId).IsRequired();
            builder.Property(roadmapCategory => roadmapCategory.RoadmapId).IsRequired();

            builder.HasOne(roadmapCategory => roadmapCategory.Category)
                .WithMany(category => category.RoadmapCategory)
                .HasForeignKey(roadmapTag => roadmapTag.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(roadmapCategory => roadmapCategory.Roadmap)
                .WithMany(roadmap => roadmap.RoadmapCategory)
                .HasForeignKey(roadmapTag => roadmapTag.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
