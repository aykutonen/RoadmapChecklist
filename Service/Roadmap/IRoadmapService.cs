using Data.UnitOfWork;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IRoadmapService
    {
        void Add(Roadmap roadmap);
        void Update(Roadmap roadmap);
        void Delete(int roadmap);
        
    }

    public class RoadmapService : IRoadmapService
    {

        public readonly IUnitOfWork _unitOfWork;

        public RoadmapService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public void Add(Roadmap roadmap)
        {
            this._unitOfWork.GetRepository<Roadmap>().Add(roadmap);
        }

        public void Update(Roadmap roadmap)
        {
            this._unitOfWork.GetRepository<Roadmap>().Update(roadmap);
        }

        public void Delete(int roadmap)
        {
            this._unitOfWork.GetRepository<Roadmap>().Delete(roadmap);
        }
    }
}
