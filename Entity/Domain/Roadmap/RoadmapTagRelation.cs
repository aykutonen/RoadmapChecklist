using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class RoadmapTagRelation : BaseEntity
    {
        //fields
        public int TagId { get; set; }
        public int RoadmapId { get; set; }

        //relations
        public Tag Tag { get; set; }
        public Roadmap Roadmap { get; set; }
    }
}
