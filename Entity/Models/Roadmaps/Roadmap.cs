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

        public User Users { get; set; }
        public ICollection<CopiedRoadmap> CopiedSourceRoadmaps { get; set; }
        public ICollection<CopiedRoadmap> CopiedTargetRoadmaps { get; set; }
        public ICollection<RoadmapItem> RoadmapItems { get; set; }
        public ICollection<RoadmapCategory> RoadmapCategories { get; set; }
        public ICollection<RoadmapTag> RoadmapTags { get; set; }
    }
}