using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Models.Categories
{
    public class Category : ModelBase
    {
        public string Name { get; set; }
        public string FriendlyUrl { get; set; }

        public virtual ICollection<RoadmapCategory> RoadmapCategory { get; set; }
    }
}
