using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Db.Entity
{
    public class RoadmapItem
    {
        
        public RoadmapItem()
        {
            DateTime dt = DateTime.UtcNow;
            CreateAt = dt;
            UpdateAt = dt;
            Status = 1;
            Order = 1;
        }

        public Guid Id { get; set; }
        public Guid RoadmapId { get; set; }
        public Guid? ParentId { get; set; }
        public int Order { get; set; }
        public int Status { get; set; }
        public String Title { get; set; }
        public string Description { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        // Relations
        public virtual Roadmap Roadmap { get; set; }
        public virtual RoadmapItem Parent { get; set; }
        public virtual ICollection<RoadmapItem> Childiren { get; set; }
    }
}
