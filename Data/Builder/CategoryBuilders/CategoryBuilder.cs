using System;
using System.Collections.Generic;
using System.Text;
using Data.Builders;
using Entity;
using Entity.Models.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builder
{
    public class CategoryBuilder:BaseEntityBuilder<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
          
            builder.Property(category => category.Name).IsRequired().HasMaxLength(255);
            builder.Property(category => category.FriendlyUrl).IsRequired().HasMaxLength(300);

            builder.HasMany(category => category.RoadmapCategory)
                .WithOne(roadmapCategory => roadmapCategory.Category)
                .HasForeignKey(roadmapCategory => roadmapCategory.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
