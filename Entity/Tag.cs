using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public string FirendlyUrl { get; set; }

        // Relations
        public virtual ICollection<RoadmapTagRelation> RoadmapTags { get; set; }
    }
}
