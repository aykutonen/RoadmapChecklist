using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;

namespace Data.Builders
{
    public class RoadmapCategoryBuilder : BaseEntityBuilder<RoadmapCategory>
    {
        public RoadmapCategoryBuilder()
        {

            ToTable("RoadmapCategory");
        }
    }
}
