using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class RoadmapItem
    {
        public int RoadmapItemId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime CreaTime { get; set; }
        public DateTime UpDateTime { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoadmapId { get; set; }
        public int ParentId { get; set; }

        public User.User User { get; set; }
        public Roadmap Roadmap { get; set; }
        public RoadmapItem ParentRoadmapItem { get; set; }
    }
}
