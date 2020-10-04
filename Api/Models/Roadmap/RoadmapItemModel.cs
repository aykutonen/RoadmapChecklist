using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models.Roadmap
{
    public class RoadmapItemModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime TargetDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RoadmapId { get; set; }
        public int ParentId { get; set; }
    }
}
