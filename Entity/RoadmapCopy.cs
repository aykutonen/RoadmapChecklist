using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class RoadmapCopy:BaseEntity
    {
        public int SourceId { get; set; }
        public int TargetId { get; set; }


        // Relations
        public virtual Roadmap SourceRoudmap { get; set; }
        public virtual Roadmap TargetRoadmap { get; set; }
    }
}
