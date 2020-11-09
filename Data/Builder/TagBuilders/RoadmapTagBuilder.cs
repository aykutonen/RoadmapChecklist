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
    public class RoadmapTagBuilder:BaseEntityBuilder<RoadmapTag>
    {
        public override void Configure(EntityTypeBuilder<RoadmapTag> builder)
        {
            builder.Property(roadmapTag => roadmapTag.TagId).IsRequired();
            builder.Property(roadmapTag => roadmapTag.RoadmapId).IsRequired();
        }
    }
}
