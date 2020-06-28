using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class Tag : BaseEntity
    {
        public string Value { get; set; }
        public string FriendlyUrl { get; set; }

        //relations
        public ICollection<RoadmapTagRelation> RoadmapTags { get; set; }
    }
}
