using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.RoadmapItem
{
    public interface IRoadmapItemService : ISave
    {
        ReturnModel<Entity.Domain.Roadmap.RoadmapItem> Create(Entity.Domain.Roadmap.RoadmapItem roadmapItemEntity);
        ReturnModel<Entity.Domain.Roadmap.RoadmapItem> Update(Entity.Domain.Roadmap.RoadmapItem roadmapItemEntity);
        ReturnModel<IEnumerable<Entity.Domain.Roadmap.RoadmapItem>> GetAll(int roadmapId);
        ReturnModel<Entity.Domain.Roadmap.RoadmapItem> Get(int roadmapItemId);
        ReturnModel<int> Delete(Entity.Domain.Roadmap.RoadmapItem roadmapItemEntity);
    }
}
