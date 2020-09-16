using Data.UnitOfWork;
using Entity.Models.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.RoadmapTags
{
    public class RoadmapTagService : IRoadmapTagService
    {
        public readonly IUnitOfWork _unitOfWork;
        public RoadmapTagService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }


        public void Add(RoadmapTag roadmaptag)
        {
            this._unitOfWork.GetRepository<RoadmapTag>().Add(roadmaptag);
        }

        public void Delete(int roadmaptag)
        {
            this._unitOfWork.GetRepository<RoadmapTag>().Delete(roadmaptag);
        }

        public void Update(RoadmapTag roadmaptag)
        {
            this._unitOfWork.GetRepository<RoadmapTag>().Add(roadmaptag);
        }
    }
}
