using System;
using System.Collections.Generic;
using System.Text;
using Data.Builders;
using Entity;
using Entity.Models.Tags;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builder
{
    public class TagBuilder : BaseEntityBuilder<Tag>
    {
        public override void Configure(EntityTypeBuilder<Tag> builder)
        {
            base.Configure(builder);
            builder.Property(tag => tag.Value).IsRequired().HasMaxLength(500);
            builder.Property(tag => tag.FriendlyUrl).IsRequired().HasMaxLength(500);

            builder.HasMany(tag => tag.RoadmapTag)
                .WithOne(roadmapTag => roadmapTag.Tag)
                .HasForeignKey(roadmapTag => roadmapTag.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
