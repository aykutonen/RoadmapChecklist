using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class RoadmapCategoryRelation : BaseEntity
    {
        public int CategoryId { get; set; }
        public int RoadmapId { get; set; }

        //relations
        public Roadmap Roadmap { get; set; }
        public Category Category { get; set; }
    }
}
