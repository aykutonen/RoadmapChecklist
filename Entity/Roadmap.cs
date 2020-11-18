using System;
using System.Collections.Generic;

namespace Entity
{
    public class Roadmap : BaseEntity
    {
        public string Name { get; set; }
        public int Visibility { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int UserId { get; set; }


        // Relations
        public virtual User User { get; set; }
        public virtual ICollection<RoadmapItem> Items { get; set; }
        public virtual ICollection<CategoryRoadmapRelation> Categories { get; set; }
        public virtual ICollection<TagRoadmapRelation> Tags { get; set; }
        public virtual ICollection<RoadmapCopy> Sources { get; set; }
        public virtual ICollection<RoadmapCopy> Targets { get; set; }
    }
}
