using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builders
{
    public class TagBuilder
    {
        public TagBuilder(EntityTypeBuilder<Tag> builder)
        {
            // fields
            builder.HasKey(tag => tag.Id);
            builder.Property(tag => tag.Id).ValueGeneratedOnAdd();
            builder.Property(tag => tag.Value).IsRequired().HasMaxLength(255);
            builder.Property(tag => tag.FriendlyUrl).IsRequired().HasMaxLength(255);

            // relations
            builder.HasMany(tag => tag.RoadmapTags)
                .WithOne(roadmapTags => roadmapTags.Tag)
                .HasForeignKey(roadmapTags => roadmapTags.TagId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
