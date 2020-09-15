using Data.Repository;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;


namespace Service.Roadmap.CopiedRoadmap
{
    public class CopiedRoadmapService : ICopiedRoadmapService
    {
       
        public readonly IUnitOfWork _unitOfWork;
        public CopiedRoadmapService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public void Add(Entity.CopiedRoadmap copiedRoadmap)
        {
            this._unitOfWork.GetRepository<Entity.CopiedRoadmap>().Add(copiedRoadmap); ;
        }

        public void Delete(int copiedRoadmap)
        {
            this._unitOfWork.GetRepository<Entity.CopiedRoadmap>().Delete(copiedRoadmap);
        }

        public void Save()
        {
            this._unitOfWork.Commmit();
        }

        public void Update(Entity.CopiedRoadmap copiedRoadmap)
        {
            this._unitOfWork.GetRepository<Entity.CopiedRoadmap>().Update(copiedRoadmap);
        }
    }
}
