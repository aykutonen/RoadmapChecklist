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
    public class RoadmapCategoryBuilder:BaseEntityBuilder<RoadmapCategory>
    {
        public override void Configure(EntityTypeBuilder<RoadmapCategory> builder)
        {
            base.Configure(builder);
       
            builder.Property(roadmapCategory => roadmapCategory.CategoryId).IsRequired();
            builder.Property(roadmapCategory => roadmapCategory.RoadmapId).IsRequired();
        }
    }
}
