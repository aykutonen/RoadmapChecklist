using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.CopiedRoadmap
{
    public interface ICopiedRoadmapService
    {
        ReturnModel<Entity.Domain.Roadmap.Roadmap> Create(int roadmapId, int userId);
    }
}
