using Entity.Models.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.RoadmapTags
{
    public interface IRoadmapTagService
    {
        ReturnModel<RoadmapTag> Add(RoadmapTag roadmapTag);
        ReturnModel<RoadmapTag> Update(RoadmapTag roadmapTag);
        ReturnModel<IEnumerable<RoadmapTag>> GetAllByUser(int roadmapTagId);
        ReturnModel<RoadmapTag> Get(int roadmapTagId);
        ReturnModel<bool> Delete(int roadmapTagId);


        //void Add(RoadmapTag roadmadtag);
        //void Update(RoadmapTag roadmaptag);
        //void Delete(int roadmaptag);
    }
}
