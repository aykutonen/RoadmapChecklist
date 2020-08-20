using Data.UnitOfWork;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.IRoadmapItem
{
    public class RoadmapItemService : IRoadmapItemService
    {

        public readonly IUnitOfWork _unitOfWork;

        public RoadmapItemService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public void Add(RoadmapItem roadmapItem)
        {
            this._unitOfWork.GetRepository<RoadmapItem>().Add(roadmapItem);
        }

        public void Delete(int roadmapItem)
        {
            this._unitOfWork.GetRepository<RoadmapItem>().Delete(roadmapItem);
        }

        public void Update(RoadmapItem roadmapItem)
        {
            this._unitOfWork.GetRepository<RoadmapItem>().Update(roadmapItem);
        }
    }
}
