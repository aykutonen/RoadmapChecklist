
using System;
using System.Collections.Generic;
using System.Text;
using Entity.Models.Roadmaps;

namespace Entity.Models.Categories
{
    public class RoadmapCategory : ModelBase
    {
        public int CategoryId { get; set; }
        public int RoadmapId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Roadmap Roadmap { get; set; }
    }
}
