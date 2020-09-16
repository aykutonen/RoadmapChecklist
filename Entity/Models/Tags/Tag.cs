using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models.Tags
{
    public class Tag : ModelBase
    {
        public string Value { get; set; }
        public string FriendlyUrl { get; set; }

        public ICollection<RoadmapTag> RoadmapTag { get; set; }
    }
}
