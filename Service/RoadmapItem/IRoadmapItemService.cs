using System;
using System.Collections.Generic;
using System.Text;

namespace Service.RoadmapItem
{
    public interface IRoadmapItemService : ISave
    {
        ReturnModel<Entity.RoadmapItem> Create(Entity.RoadmapItem item);
        ReturnModel<Entity.RoadmapItem> Update(Entity.RoadmapItem item);
        ReturnModel<Entity.RoadmapItem> Get(int id);
        ReturnModel<List<Entity.RoadmapItem>> GetByRoadmap(int roadmapid);
    }
}
