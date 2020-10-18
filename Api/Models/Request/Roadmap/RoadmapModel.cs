using System;

namespace Api.Models.Request.Roadmap
{
    public class RoadmapModel
    {
        public string Name { get; set; }
        public int Visibility { get; set; }
        public int Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public int TagId { get; set; }
    }
}