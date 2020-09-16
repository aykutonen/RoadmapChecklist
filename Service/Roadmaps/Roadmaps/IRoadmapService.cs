using Entity.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmaps.Roadmaps
{
    public interface IRoadmapService
    {
        ReturnModel<Roadmap> Add(Roadmap roadmapEntity);
        ReturnModel<Roadmap> Update(Roadmap roadmapEntity);
        ReturnModel<IEnumerable<Roadmap>> GetAllByUser(int userId);
        ReturnModel<Roadmap> Get(int roadmapId);
        ReturnModel<bool> Delete(int roadmapId);


        //void Add(Roadmap roadmap);
        //void Update(Roadmap roadmap);
        //void Delete(int roadmap);

    }
}
