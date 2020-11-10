using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap
{
    public interface IRoadmapService : ISave
    {
        ReturnModel<Entity.Roadmap> Create(Entity.Roadmap roadmap);
        ReturnModel<Entity.Roadmap> Update(Entity.Roadmap roadmap);
        ReturnModel<Entity.Roadmap> Get(int id);
        ReturnModel<List<Entity.Roadmap>> GetByUser(int userid);
    }
}
