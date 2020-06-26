using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class RoadmapTag
    {
        public int RoadmapTagId { get; set; }
        public int TagId { get; set; }
        public int RoadmapId { get; set; }

        public Roadmap Roadmap { get; set; }
        public Tag Tag { get; set; }
    }
}
