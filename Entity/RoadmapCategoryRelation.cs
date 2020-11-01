using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class RoadmapCategoryRelation : BaseEntity
    {
        public int CategoryId { get; set; }
        public int RoadmapId { get; set; }

        // Relations
        public virtual Category Category { get; set; }
        public virtual Roadmap Roadmap { get; set; }
    }
}
