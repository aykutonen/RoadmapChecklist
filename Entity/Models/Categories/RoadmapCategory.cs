using Entity.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models.Categories
{
    public class RoadmapCategory : ModelBase
    {
        public int CategoryId { get; set; }
        public int RoadmapId { get; set; }

        public Category Category { get; set; }
        public Roadmap Roadmap { get; set; }
    }
}
