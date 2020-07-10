using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entity
{
    public class Roadmap : ModelBase
    {
        public string Name { get; set; }
        public int Visibility { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
        public ICollection<RoadmapItem> RoadmapItem { get; set; }
        public ICollection<CopiedRoadmap> CopiedRoadmap { get; set; }
        public ICollection<RoadmapCategory> RoadmapCategory { get; set; }
        public ICollection<RoadmapTag> RoadmapTag { get; set; }
    }
}