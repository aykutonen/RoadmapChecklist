using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.CopiedRoadmap
{
    public interface ICopiedRoadmapService
    {
        void Add(Entity.CopiedRoadmap copiedRoadmap);
        void Update(Entity.CopiedRoadmap copiedRoadmap);
        void Delete(int copiedRoadmap);
    }
}
