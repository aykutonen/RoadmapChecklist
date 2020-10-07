using Entity.Models.Roadmaps;
using Service.Roadmaps.CopiedRoadmaps.Models;
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
        ReturnModel<CopiedRoadmap> Get(int copiedRoadmapId);
        ReturnModel<bool> Delete(int copiedRoadmapId);
        ReturnModel<CopiedRoadmap> AddCopy(CopiedRoadmapViewModel copiedRoadmapViewModel);
    }
}
