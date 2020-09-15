using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tag.RoadmapTag
{
    public interface IRoadmapTagService
    {
        void Add(Entity.RoadmapTag roadmadtag);
        void Update(Entity.RoadmapTag roadmaptag);
        void Delete(int roadmaptag);
    }
}
