using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.CopiedRoadmap
{
    public interface ICopiedRoadmapService
    {
        ReturnModel<Entity.Domain.Roadmap.CopiedRoadmaps> Create(int roadmapId, int userId);
    }
}
