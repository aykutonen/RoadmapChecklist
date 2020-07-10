using System;
using System.Collections.Generic;
using System.Text;

namespace Entity
{
    public class Category : ModelBase
    {
        public string Value { get; set; }
        public string FriendlyUrl { get; set; }

        public ICollection<RoadmapCategory> RoadmapCategory { get; set; }
    }
}
