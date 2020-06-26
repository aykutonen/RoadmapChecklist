using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class CopiedRoadmaps
    {
        public int CopiedRoadmapId { get; set; }
        public int SourceRoadmapId { get; set; }
        public int TargetRoadmapId { get; set; }
        public DateTime CreaTime { get; set; }
        public int RoadmapId { get; set; }

        public Roadmap Roadmap { get; set; }
    }
}
