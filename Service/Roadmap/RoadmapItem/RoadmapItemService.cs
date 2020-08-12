using System;
using System.Collections.Generic;
using System.Text;
using Data.Infrastructure.Repository;
using Data.Infrastructure.UnitOfWork;

namespace Service.Roadmap.RoadmapItem
{
    public class RoadmapItemService : IRoadmapItemService
    {
        private readonly IRepository<Entity.Domain.Roadmap.RoadmapItem> repository;
        private readonly IUnitOfWork unitOfWork;

        public RoadmapItemService(IRepository<Entity.Domain.Roadmap.RoadmapItem> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public ReturnModel<Entity.Domain.Roadmap.RoadmapItem> Create(Entity.Domain.Roadmap.RoadmapItem roadmapItemEntity)
        {
            var result = new ReturnModel<Entity.Domain.Roadmap.RoadmapItem>();

            try
            {
                repository.Add(roadmapItemEntity);
                result.Data = roadmapItemEntity;
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<Entity.Domain.Roadmap.RoadmapItem> Update(Entity.Domain.Roadmap.RoadmapItem roadmapItemEntity)
        {
            var result = new ReturnModel<Entity.Domain.Roadmap.RoadmapItem>();

            try
            {
                repository.Update(roadmapItemEntity);
                result.Data = roadmapItemEntity;
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<IEnumerable<Entity.Domain.Roadmap.RoadmapItem>> GetAll(int roadmapId)
        {
            var result = new ReturnModel<IEnumerable<Entity.Domain.Roadmap.RoadmapItem>>();

            try
            {
                result.Data = repository.GetList(roadmapItem => roadmapItem.RoadmapId == roadmapId);
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<Entity.Domain.Roadmap.RoadmapItem> Get(int roadmapItemId)
        {
            var result = new ReturnModel<Entity.Domain.Roadmap.RoadmapItem>();

            try
            {
                result.Data = repository.Get(roadmapItem => roadmapItem.Id == roadmapItemId);
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<int> Delete(Entity.Domain.Roadmap.RoadmapItem roadmapItemEntity)
        {
            var result = new ReturnModel<int>();

            try
            {
                 repository.Delete(roadmapItemEntity);
                 result.Data = roadmapItemEntity.Id;
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
