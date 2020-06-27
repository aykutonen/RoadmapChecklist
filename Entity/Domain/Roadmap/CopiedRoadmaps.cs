using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class CopiedRoadmaps : AuditableEntity
    {
        public int SourceRoadmapId { get; set; }
        public int TargetRoadmapId { get; set; }
        public int RoadmapId { get; set; }

        public Roadmap Roadmap { get; set; }
    }
}
