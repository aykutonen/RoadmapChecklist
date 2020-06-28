using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class Roadmap : AuditableEntity
    {
        public string Name { get; set; }
        public int Visibility { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }

        //relations
        public User.User User { get; set; }
        public ICollection<CopiedRoadmaps> CopiedRoadmaps { get; set; }
        public ICollection<RoadmapItem> RoadmapItems { get; set; }
        public ICollection<RoadmapCategoryRelation> RoadmapCategories { get; set; }
        public ICollection<RoadmapTagRelation> RoadmapTags { get; set; }
    }
}
