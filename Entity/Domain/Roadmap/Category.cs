using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class Category : BaseEntity
    {
        //fields
        public string Value { get; set; }
        public string FriendlyUrl { get; set; }

        //relations
        public ICollection<RoadmapCategoryRelation> RoadmapCategories { get; set; }
    }
}
