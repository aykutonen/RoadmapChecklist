using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class CopiedRoadmaps : AuditableEntity
    {
        //fields
        public int SourceRoadmapId { get; set; }
        public int TargetRoadmapId { get; set; }

        //relations
        public Roadmap Roadmap { get; set; }
    }
}
