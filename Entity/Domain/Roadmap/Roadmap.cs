using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.Domain.Roadmap
{
    public class Roadmap
    {
        public int RoadmapId { get; set; }
        public string Name { get; set; }
        public int Visibility { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreaTime { get; set; }
        public DateTime UpDateTime { get; set; }
        public int UserId { get; set; }

        public User.User User { get; set; }
        public ICollection<Roadmap> Roadmaps { get; set; }
    }
}
