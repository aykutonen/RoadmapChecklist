using Entity.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Categories.RoadmapCategory
{
    public interface IRoadmapCategoryService
    {
        ReturnModel<RoadmapCategory> Add(RoadmapCategory roadmapCategory);
        ReturnModel<RoadmapCategory> Update(RoadmapCategory roadmapCategory);
        ReturnModel<IEnumerable<RoadmapCategory>> GetAllByUser(int roadmapCategoryId);
        ReturnModel<RoadmapCategory> Get(int roadmapCategoryId);
        ReturnModel<bool> Delete(int roadmapCategoryId);

        //void Add(RoadmapCategory roadmapCategory);
        //void Update(RoadmapCategory roadmapCategory);
        //void Delete(int roadmapCategory);
    }
}
