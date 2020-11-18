using System.Collections.Generic;

namespace Service.Roadmap
{
    public interface IRoadmapService : ISave
    {
        ReturnModel<Entity.Roadmap> Create(Entity.Roadmap roadmap);
        ReturnModel<Entity.Roadmap> Update(Entity.Roadmap roadmap);
        ReturnModel<Entity.Roadmap> Get(int id);
        ReturnModel<List<Entity.Roadmap>> GetByUser(int userid);
        ReturnModel<Entity.Roadmap> Copy(int id, int userid);
    }
}
