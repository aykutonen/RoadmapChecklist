using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.IRoadmapItem
{
    public interface IRoadmapItemService
    {

        ReturnModel<Entity.RoadmapItem> Add(Entity.RoadmapItem roadmapItem);
        ReturnModel<Entity.RoadmapItem> Update(Entity.RoadmapItem roadmapItem);
        ReturnModel<IEnumerable<Entity.RoadmapItem>> GetAllByUser(int userId);
        ReturnModel<Entity.RoadmapItem> Get(int roadmapItemId);
        ReturnModel<int> Delete(int roadmapItem);

        //void Add(RoadmapItem roadmapItem);
        //void Update(RoadmapItem roadmapItem);
        //void Delete(int roadmapItem);
    }
}
