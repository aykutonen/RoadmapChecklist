using Entity;
using Entity.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmaps.IRoadmapItems
{
    public interface IRoadmapItemService
    {

        ReturnModel<RoadmapItem> Add(RoadmapItem roadmapItem);
        ReturnModel<RoadmapItem> Update(RoadmapItem roadmapItem);
        ReturnModel<IEnumerable<RoadmapItem>> GetAllByUser(int userId);
        ReturnModel<RoadmapItem> Get(int roadmapItemId);
        ReturnModel<int> Delete(int roadmapItemId);

        //void Add(RoadmapItem roadmapItem);
        //void Update(RoadmapItem roadmapItem);
        //void Delete(int roadmapItem);
    }
}
