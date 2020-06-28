using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class RoadmapCategoryRelation : BaseEntity
    {
        //fields
        public int CategoryId { get; set; }
        public int RoadmapId { get; set; }

        //relations
        public Category Category { get; set; }
        public Roadmap Roadmap { get; set; }
    }
}
