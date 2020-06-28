using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class RoadmapItem : AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoadmapId { get; set; }
        public int ParentId { get; set; }

        //relations
        public Roadmap Roadmap { get; set; }
        public RoadmapItem ParentRoadmapItem { get; set; }
    }
}
