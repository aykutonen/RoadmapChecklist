using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builder
{
    public class CategoryBuilder
    {
        public CategoryBuilder(EntityTypeBuilder<Category> builder)
        {
            // fields
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Id).ValueGeneratedOnAdd();
            builder.Property(category => category.Value).IsRequired().HasMaxLength(500);
            builder.Property(category => category.FriendlyUrl).IsRequired().HasMaxLength(500);

            builder.HasMany(category => category.RoadmapCategory)
                .WithOne(roadmapCategory => roadmapCategory.Category)
                .HasForeignKey(roadmapCategory => roadmapCategory.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
