using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class TagRoadmapRelation : BaseEntity
    {
        public int TagId { get; set; }
        public int RoadmapId { get; set; }

        // Relations
        public virtual Tag Tag { get; set; }
        public virtual Roadmap Roadmap { get; set; }
    }
}
