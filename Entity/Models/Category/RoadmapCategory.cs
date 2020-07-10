using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class RoadmapCategory : ModelBase
    {
        public int CategoryId { get; set; }
        public int RoadmapId { get; set; }

        public Category Category { get; set; }
        public Roadmap Roadmap { get; set; }
    }
}
