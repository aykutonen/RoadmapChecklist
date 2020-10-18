using System;
using Data.Infrastructure.Repository;
using Data.Infrastructure.UnitOfWork;
using Entity.Domain.Roadmap;

namespace Service.Roadmap.RoadmapTag
{
    public class RoadmapTagService : IRoadmapTagService
    {
        private IRoadmapService _roadmapService;
        private readonly IRepository<RoadmapTagRelation> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RoadmapTagService(IRoadmapService roadmapService, IRepository<RoadmapTagRelation> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _roadmapService = roadmapService;
        }

        public ReturnModel<Entity.Domain.Roadmap.Roadmap> Create(RoadmapTagRelation roadmapTagEntity)
        {
            var result = new ReturnModel<Entity.Domain.Roadmap.Roadmap>();

            try
            {
                var roadmapToUpdate = _roadmapService.Get(roadmapTagEntity.RoadmapId);

                if (roadmapToUpdate != null)
                {
                    //_repository.Add(roadmapTagEntity);
                    roadmapToUpdate.Data.RoadmapTags.Add(roadmapTagEntity);
                    
                    var updatedRoadmap = _roadmapService.Update(roadmapToUpdate.Data);
                    result.Data = updatedRoadmap.Data;
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