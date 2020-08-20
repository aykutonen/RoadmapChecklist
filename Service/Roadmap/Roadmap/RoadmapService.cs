using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.Roadmap
{
    public class RoadmapService:IRoadmapService
    {
        public readonly IUnitOfWork _unitOfWork;

        public RoadmapService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public void Add(Entity.Roadmap roadmap)
        {
            this._unitOfWork.GetRepository<Entity.Roadmap>().Add(roadmap);
        }

        public void Delete(int roadmap)
        {
            this._unitOfWork.GetRepository<Entity.Roadmap>().Delete(roadmap);
        }

        public void Update(Entity.Roadmap roadmap)
        {
            this._unitOfWork.GetRepository<Entity.Roadmap>().Update(roadmap);
        }
    }
}
