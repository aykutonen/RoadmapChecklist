using System;
using System.Collections.Generic;
using System.Text;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builder
{
    public class TagBuilder
    {
        public TagBuilder(EntityTypeBuilder<Tag> builder)
        {
            // fields
            builder.HasKey(tag => tag.Id);
            builder.Property(tag => tag.Id).ValueGeneratedOnAdd();
            builder.Property(tag => tag.Value).IsRequired().HasMaxLength(500);
            builder.Property(tag => tag.FriendlyUrl).IsRequired().HasMaxLength(500);

            builder.HasMany(tag => tag.RoadmapTag)
                .WithOne(roadmapTag => roadmapTag.Tag)
                .HasForeignKey(roadmapTag => roadmapTag.TagId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
