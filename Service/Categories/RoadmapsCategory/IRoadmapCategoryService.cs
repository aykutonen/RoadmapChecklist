using Entity.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Categories.RoadmapsCategory
{
    public interface IRoadmapCategoryService
    {
        void Add(RoadmapCategory roadmapCategory);
        void Update(RoadmapCategory roadmapCategory);
        void Delete(int roadmapCategory);
    }
}
