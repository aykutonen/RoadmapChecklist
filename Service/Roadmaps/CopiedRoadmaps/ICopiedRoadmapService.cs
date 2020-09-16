using Entity.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmaps.CopiedRoadmaps
{
    public interface ICopiedRoadmapService
    {
        ReturnModel<CopiedRoadmap> Add(CopiedRoadmap copiedRoadmap);
        ReturnModel<CopiedRoadmap> Update(CopiedRoadmap copiedRoadmap);
        ReturnModel<IEnumerable<CopiedRoadmap>> GetAllByUser(int copiedRoadmapId);
        ReturnModel<CopiedRoadmap> Get(int userId);
        ReturnModel<bool> Delete(int copiedRoadmapId);

        //void Add(CopiedRoadmap copiedRoadmap);
        //void Update(CopiedRoadmap copiedRoadmap);
        //void Delete(int copiedRoadmap);
    }
}
