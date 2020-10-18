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
                    roadmapToUpdate.Data.RoadmapCategories.Add(roadmapCategoryEntity);

                    _repository.Add(roadmapCategoryEntity);
                    result.Data = roadmapCategoryEntity.Roadmap;
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