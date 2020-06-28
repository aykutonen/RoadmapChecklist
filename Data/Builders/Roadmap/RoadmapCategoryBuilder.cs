using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class RoadmapCategoryBuilder
    {
        public RoadmapCategoryBuilder(EntityTypeBuilder<RoadmapCategoryRelation> builder)
        {
            //fields
            builder.HasKey(roadmapTag => roadmapTag.Id);
            builder.Property(roadmapTag => roadmapTag.Id).ValueGeneratedOnAdd();
            builder.Property(roadmapTag => roadmapTag.CategoryId).IsRequired();
            builder.Property(roadmapTag => roadmapTag.RoadmapId).IsRequired();

            //relations
            builder.HasOne(roadmapCategory => roadmapCategory.Category)
                .WithMany(category=> category.RoadmapCategories)
                .HasForeignKey(roadmapTag => roadmapTag.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasOne(roadmapCategory => roadmapCategory.Roadmap)
                .WithMany(roadmap => roadmap.RoadmapCategories)
                .HasForeignKey(roadmapTag => roadmapTag.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
