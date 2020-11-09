﻿using System;
using System.Collections.Generic;
using System.Text;
using Data.Builders;
using Entity;
using Entity.Models.Roadmaps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builder
{
    public class RoadmapItemBuilder: BaseEntityBuilder<RoadmapItem>
    {
        public override void Configure(EntityTypeBuilder<RoadmapItem> builder)
        {
            //fields
            builder.HasKey(roadmapItem => roadmapItem.Id);
            builder.Property(roadmapItem => roadmapItem.Id).ValueGeneratedOnAdd();
            builder.Property(roadmapItem => roadmapItem.Title).IsRequired().HasMaxLength(500);
            builder.Property(roadmapItem => roadmapItem.Description).IsRequired().HasMaxLength(500);
            builder.Property(roadmapItem => roadmapItem.Status).IsRequired();
            builder.Property(roadmapItem => roadmapItem.TargetEndDate).IsRequired();
            builder.Property(roadmapItem => roadmapItem.EndDate).IsRequired();



            builder.HasOne(roadmapItem => roadmapItem.Roadmap)
                .WithMany(roadmap => roadmap.RoadmapItems)
                .HasForeignKey(roadmapItems => roadmapItems.RoadmapId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            builder.HasMany(roadmapItem => roadmapItem.RoadmapItems)
                .WithOne(roadmapItem => roadmapItem.ParentRoadmapItem)
                .HasForeignKey(roadmapItem => roadmapItem.ParentId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
