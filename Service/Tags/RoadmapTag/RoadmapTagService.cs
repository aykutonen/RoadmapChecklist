using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tag.RoadmapTag
{
    public class RoadmapTagService : IRoadmapTagService
    {
        public readonly IUnitOfWork _unitOfWork;
        public RoadmapTagService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }


        public void Add(Entity.RoadmapTag roadmaptag)
        {
            this._unitOfWork.GetRepository<Entity.RoadmapTag>().Add(roadmaptag);
        }

        public void Delete(int roadmaptag)
        {
            this._unitOfWork.GetRepository<Entity.RoadmapTag>().Delete(roadmaptag);
        }

        public void Update(Entity.RoadmapTag roadmaptag)
        {
            this._unitOfWork.GetRepository<Entity.RoadmapTag>().Add(roadmaptag);
        }
    }
}
