using Entity.Models.Categories;
using Entity.Models.Tags;
using Entity.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity.Models.Roadmaps
{
    public class Roadmap : ModelBase
    {
        public string Name { get; set; }
        public int Visibility { get; set; } = 1;
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }

        public virtual User Users { get; set; }
        public virtual ICollection<RoadmapItem> RoadmapItems { get; set; }
        public virtual ICollection<RoadmapCategory> RoadmapCategories { get; set; }
        public virtual ICollection<RoadmapTag> RoadmapTags { get; set; }
        public virtual CopiedRoadmap Source { get; set; }
        public virtual ICollection<CopiedRoadmap> Targets{ get; set; }
    }
}