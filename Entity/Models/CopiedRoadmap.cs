using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class CopiedRoadmap : ModelBase
    {
        public int SourceRoadmapId { get; set; }
        public int TargetRoadmapId { get; set; }
        public DateTime CreateTime { get; set; }

        public virtual Roadmap SourceRoadmap { get; set; }
        public virtual Roadmap TargetRoadmap { get; set; }
    }
}
