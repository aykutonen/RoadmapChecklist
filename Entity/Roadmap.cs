using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Principal;
using System.Text;

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
        public virtual ICollection<CategoryRoadmapRelation> RoadmapCategories { get; set; }
        public virtual ICollection<TagRoadmapRelation> RoadmapTags { get; set; }
        public virtual RoadmapCopy SourceRoadmap { get; set; }
        public virtual ICollection<RoadmapCopy> TargetRoadmaps { get; set; }
    }
}
