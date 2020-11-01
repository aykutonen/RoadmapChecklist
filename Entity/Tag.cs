using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public string FriendlyUrl { get; set; }

        // Relations
        public virtual ICollection<TagRoadmapRelation> RoadmapTags { get; set; }
    }
}
