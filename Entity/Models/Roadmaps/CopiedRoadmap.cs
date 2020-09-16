using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models.Roadmaps
{
    public class CopiedRoadmap : ModelBase
    {
        public int SourceRoadmapId { get; set; }
        public int TargetRoadmapId { get; set; }
        public DateTime CreateTime { get; set; }

        public Roadmap SourceRoadmap { get; set; }
        public Roadmap TargetRoadmap { get; set; }
    }
}
