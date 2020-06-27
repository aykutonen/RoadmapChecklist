using System;
using System.Collections.Generic;
using System.Text;
using Entity.Domain.Roadmap;

namespace Data.Builders
{
    public class RoadmapTagBuilder : BaseEntityBuilder<RoadmapTag>
    {
        public RoadmapTagBuilder()
        {

            ToTable("RoadmapTag");
        }
    }
}
