using System;
using System.Collections.Generic;
using System.Text;
using Data.Builders;
using Entity;
using Entity.Models.Roadmaps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Builder
{
    public class CopiedRoadmapBuilder:BaseEntityBuilder<CopiedRoadmap>
    {
        public override void Configure(EntityTypeBuilder<CopiedRoadmap> builder)
        {
            base.Configure(builder);

            builder.Property(copiedRoadmaps => copiedRoadmaps.SourceId).IsRequired();
            builder.Property(copiedRoadmaps => copiedRoadmaps.TargetId).IsRequired();

        }
    }
}
