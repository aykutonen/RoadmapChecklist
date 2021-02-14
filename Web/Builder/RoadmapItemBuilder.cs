using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Db.Entity;

namespace Web.Builder
{
    public class RoadmapItemBuilder : IEntityTypeConfiguration<RoadmapItem>
    {
        public void Configure(EntityTypeBuilder<RoadmapItem> builder)
        {
            builder.HasKey(ri => ri.Id);
            builder.Property(ri => ri.Id).ValueGeneratedOnAdd();
            builder.Property(ri => ri.Title).IsRequired().HasMaxLength(500);
            builder.Property(ri => ri.CreateAt).IsRequired();
            builder.Property(ri => ri.CreateAt).IsRequired();
            builder.Property(ri => ri.Status).IsRequired().HasDefaultValue(1);
            builder.Property(ri => ri.Order).IsRequired().HasDefaultValue(1);
            builder.Property(ri => ri.RoadmapId).IsRequired();


            builder.HasOne(ri => ri.Roadmap)
                .WithMany(r => r.Items)
                .HasForeignKey(ri => ri.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(ri => ri.Childiren)
                .WithOne(ri => ri.Parent)
                .HasForeignKey(ri => ri.ParentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
