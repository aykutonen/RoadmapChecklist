using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.Roadmap
{
    public interface IRoadmapService
    {
        ReturnModel<Entity.Roadmap> Add(Entity.Roadmap roadmapEntity);
        ReturnModel<Entity.Roadmap> Update(Entity.Roadmap roadmapEntity);
        ReturnModel<IEnumerable<Entity.Roadmap>> GetAllByUser(int userId);
        ReturnModel<Entity.Roadmap> Get(int roadmapId);
        ReturnModel<int> Delete(int roadmapEntity);
        //void Add(Entity.Roadmap roadmap);
        //void Update(Entity.Roadmap roadmap);
        //void Delete(int roadmap);

    }
}
