using Entity.Models.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.RoadmapTags
{
    public interface IRoadmapTagService
    {
        void Add(RoadmapTag roadmadtag);
        void Update(RoadmapTag roadmaptag);
        void Delete(int roadmaptag);
    }
}
