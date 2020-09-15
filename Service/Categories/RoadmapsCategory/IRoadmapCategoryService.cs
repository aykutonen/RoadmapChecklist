using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Category.RoadmapCategory
{
    public interface IRoadmapCategoryService
    {
        void Add(Entity.RoadmapCategory roadmapCategory);
        void Update(Entity.RoadmapCategory roadmapCategory);
        void Delete(int roadmapCategory);
    }
}
