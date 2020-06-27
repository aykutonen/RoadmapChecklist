using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;

namespace Data.Builders
{
    public class RoadmapItemBuilder : BaseEntityBuilder<RoadmapItem>
    {
        public RoadmapItemBuilder()
        {
            Property(roadmapItem => roadmapItem.Title).IsRequired().HasMaxLength(255);
            Property(roadmapItem => roadmapItem.Description).IsRequired().HasMaxLength(525);
            Property(roadmapItem => roadmapItem.Status).IsRequired();
            Property(roadmapItem => roadmapItem.TargetDate).IsRequired();
            Property(roadmapItem => roadmapItem.EndDate).IsRequired();

            //relations

            //table
            ToTable("RoadmapItem");
        }
    }
}
