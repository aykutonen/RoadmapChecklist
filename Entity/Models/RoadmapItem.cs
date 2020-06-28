using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class RoadmapItem : ModelBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime TargetEndDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoadmapId { get; set; }
        public int ParentId { get; set; }

        public virtual Roadmap Roadmap { get; set; }

    }
}
