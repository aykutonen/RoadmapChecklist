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
        // TODO: Roadmap ilişkilerini tanımla.
        public virtual ICollection<RoadmapCategoryRelation> RoadmapCategories { get; set; }
        public virtual ICollection<RoadmapTagRelation> RoadmapTags { get; set; }
    }
}
