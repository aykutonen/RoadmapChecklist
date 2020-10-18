using System.Collections.Generic;
using Entity.Domain.Roadmap;

namespace Api.Models.Response
{
    public class RoadmapWithItemsResponseModel
    {
        public Entity.Domain.Roadmap.Roadmap Roadmap { get; set; }
        public IEnumerable<RoadmapItem> RoadmapItems { get; set; }
    }
}