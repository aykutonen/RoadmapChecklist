using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class CategoryBuilder
    {
        public CategoryBuilder(EntityTypeBuilder<Category> builder)
        {
            // fields
            builder.HasKey(category => category.Id);
            builder.Property(category => category.Id).ValueGeneratedOnAdd();
            builder.Property(category => category.Value).IsRequired().HasMaxLength(255);
            builder.Property(category => category.FriendlyUrl).IsRequired().HasMaxLength(255);

            // relations
            builder.HasMany(category => category.RoadmapCategories)
                .WithOne(roadmapCategories => roadmapCategories.Category)
                .HasForeignKey(roadmapCategories => roadmapCategories.CategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

        }
    }
}
