using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap
{
    public interface IRoadmapService : ISave
    {
        ReturnModel<Entity.Domain.Roadmap.Roadmap> Create(Entity.Domain.Roadmap.Roadmap roadmapEntity);
        ReturnModel<Entity.Domain.Roadmap.Roadmap> Update(Entity.Domain.Roadmap.Roadmap roadmapEntity);
        ReturnModel<IEnumerable<Entity.Domain.Roadmap.Roadmap>> GetAllByUser(int userId);
        ReturnModel<Entity.Domain.Roadmap.Roadmap> Get(int roadmapId);
        ReturnModel<int> Delete(int roadmapId);
    }
}
