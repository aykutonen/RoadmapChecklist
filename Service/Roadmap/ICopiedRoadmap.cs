using Data.UnitOfWork;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface ICopiedRoadmap
    {
        void Add(CopiedRoadmap copiedRoadmap);
        void Update(CopiedRoadmap copiedRoadmap);
        void Delete(int copiedRoadmap);
    }

    public class CopiedRoadmapService : ICopiedRoadmap

    {
        public readonly IUnitOfWork _unitOfWork;
        public CopiedRoadmapService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }


        public void Add(CopiedRoadmap copiedRoadmap)
        {
            this._unitOfWork.GetRepository<CopiedRoadmap>().Add(copiedRoadmap);
        }

        public void Delete(int copiedRoadmap)
        {
            this._unitOfWork.GetRepository<CopiedRoadmap>().Delete(copiedRoadmap);
        }

        public void Update(CopiedRoadmap copiedRoadmap)
        {
            this._unitOfWork.GetRepository<CopiedRoadmap>().Update(copiedRoadmap);
        }
    }
}
