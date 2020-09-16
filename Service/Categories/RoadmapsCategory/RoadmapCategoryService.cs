using Data.UnitOfWork;
using Entity.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Categories.RoadmapsCategory
{
    public class RoadmapCategoryService : IRoadmapCategoryService
    {
        public readonly IUnitOfWork _unitOfWork;
        public RoadmapCategoryService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }


        public void Add(RoadmapCategory roadmapCategory)
        {
            this._unitOfWork.GetRepository<RoadmapCategory>().Add(roadmapCategory);
        }

        public void Delete(int roadmapCategory)
        {
            this._unitOfWork.GetRepository<RoadmapCategory>().Delete(roadmapCategory);
        }

        public void Update(RoadmapCategory roadmapCategory)
        {
            this._unitOfWork.GetRepository<RoadmapCategory>().Update(roadmapCategory);
        }
    }
}
