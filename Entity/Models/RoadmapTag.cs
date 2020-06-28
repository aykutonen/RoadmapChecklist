using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class RoadmapTag : ModelBase
    {
        public int TagId { get; set; }
        public int RoadmapId { get; set; }

        public virtual Tag Tag { get; set; }
        public virtual Roadmap Roadmap { get; set; }

    }
}
