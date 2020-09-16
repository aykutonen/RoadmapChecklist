using Entity.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models.Tags
{
    public class RoadmapTag : ModelBase
    {
        public int TagId { get; set; }
        public int RoadmapId { get; set; }

        public Tag Tag { get; set; }
        public Roadmap Roadmap { get; set; }

    }
}
