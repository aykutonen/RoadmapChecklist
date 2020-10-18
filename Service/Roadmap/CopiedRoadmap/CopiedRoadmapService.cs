using Data.Infrastructure.Repository;
using Data.Infrastructure.UnitOfWork;
using Entity.Domain.Roadmap;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.CopiedRoadmap
{
    public class CopiedRoadmapService : ICopiedRoadmapService
    {
        private readonly IRepository<Entity.Domain.Roadmap.Roadmap> _roadmapRepository;
        private readonly IRepository<CopiedRoadmaps> _copiedRoadmapRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CopiedRoadmapService(IRepository<Entity.Domain.Roadmap.Roadmap> roadmapRepository, IRepository<CopiedRoadmaps> copiedRoadmapRepository, IUnitOfWork unitOfWork)
        {
            _roadmapRepository = roadmapRepository;
            _copiedRoadmapRepository = copiedRoadmapRepository;
            _unitOfWork = unitOfWork;
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public ReturnModel<CopiedRoadmaps> Create(int roadmapId)
        {
            var result = new ReturnModel<CopiedRoadmaps>();

            try
            {
                if (roadmapId <= 0 /*userAuthentication*/)
                {
                    var roadmapEntity = _roadmapRepository.Get(roadmap => roadmap.Id == roadmapId);
                    _roadmapRepository.Add(roadmapEntity); //userid,roadmapid control

                    var copiedRoadmapToAdd = new CopiedRoadmaps()
                    {
                        SourceRoadmapId = roadmapId,
                        TargetRoadmapId = roadmapEntity.Id
                    };
                    
                    
                    _copiedRoadmapRepository.Add(copiedRoadmapToAdd); //roadmapentity.copiedroadmaps

                    result.Data = copiedRoadmapToAdd;
                }
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }
    }
}
