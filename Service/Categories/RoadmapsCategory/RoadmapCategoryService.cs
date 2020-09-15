using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Category.RoadmapCategory
{
    public class RoadmapCategoryService : IRoadmapCategoryService
    {
        public readonly IUnitOfWork _unitOfWork;
        public RoadmapCategoryService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }


        public void Add(Entity.RoadmapCategory roadmapCategory)
        {
            this._unitOfWork.GetRepository<Entity.RoadmapCategory>().Add(roadmapCategory);
        }

        public void Delete(int roadmapCategory)
        {
            this._unitOfWork.GetRepository<Entity.RoadmapCategory>().Delete(roadmapCategory);
        }

        public void Update(Entity.RoadmapCategory roadmapCategory)
        {
            this._unitOfWork.GetRepository<Entity.RoadmapCategory>().Update(roadmapCategory);
        }
    }
}
