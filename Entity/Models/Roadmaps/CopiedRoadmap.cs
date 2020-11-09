using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models.Roadmaps
{
    public class CopiedRoadmap : ModelBase
    {
        public int SourceId { get; set; }
        public int TargetId { get; set; }

        public virtual Roadmap SourceRoadmap { get; set; }
        public virtual Roadmap TargetRoadmap { get; set; }
    }
}
