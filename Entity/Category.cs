using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string FriendlyUrl { get; set; }

        // Relations
        public virtual ICollection<CategoryRoadmapRelation> RoadmapCategories { get; set; }
    }
}
