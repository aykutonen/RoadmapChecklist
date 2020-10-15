using System;
using Data.Infrastructure.Repository;
using Data.Infrastructure.UnitOfWork;
using Entity.Domain.Roadmap;

namespace Service.Roadmap.RoadmapCategory
{
    public class RoadmapCategoryService : IRoadmapCategoryService
    {
        private IRoadmapService _roadmapService;
        private readonly IRepository<RoadmapCategoryRelation> _repository;
        private readonly IUnitOfWork _unitOfWork;
        
        public ReturnModel<Entity.Domain.Roadmap.Roadmap> Create(RoadmapCategoryRelation roadmapCategoryEntity)
        {
            var result = new ReturnModel<Entity.Domain.Roadmap.Roadmap>();

            try
            {
                var roadmapToUpdate = _roadmapService.Get(roadmapCategoryEntity.RoadmapId);

                if (roadmapToUpdate != null)
                {
                    _repository.Add(roadmapCategoryEntity);
                    roadmapToUpdate.Data.RoadmapCategories.Add(roadmapCategoryEntity);
                    
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