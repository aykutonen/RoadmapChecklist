using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.IRoadmapItem
{
    public interface IRoadmapItemService
    {
        void Add(RoadmapItem roadmapItem);
        void Update(RoadmapItem roadmapItem);
        void Delete(int roadmapItem);
    }
}
