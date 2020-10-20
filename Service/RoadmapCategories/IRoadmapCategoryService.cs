using Entity.Models.Categories;
using Entity.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.Text;
namespace Service.RoadmapCategories
{
    public interface IRoadmapCategoryService
    {
        //ReturnModel<RoadmapCategory> Add(RoadmapCategory roadmapCategory);
        //ReturnModel<RoadmapCategory> Update(RoadmapCategory roadmapCategory);
        //ReturnModel<IEnumerable<RoadmapCategory>> GetAllByUser(int roadmapCategoryId);
        //ReturnModel<RoadmapCategory> Get(int roadmapCategoryId);
        //ReturnModel<bool> Delete(int roadmapCategoryId);
        ReturnModel<Roadmap> Create(RoadmapCategory roadmapCategory);
    }
}
