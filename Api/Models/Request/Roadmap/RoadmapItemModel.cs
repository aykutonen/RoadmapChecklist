using System;

namespace Api.Models.Request.Roadmap
{
    public class RoadmapItemModel //validasyon kontrolü ekle
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
