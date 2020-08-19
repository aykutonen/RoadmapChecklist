using System;
using System.Collections.Generic;
using System.Text;
using Data.Infrastructure.Repository;
using Data.Infrastructure.UnitOfWork;

namespace Service.Roadmap
{
    public class RoadmapService : IRoadmapService
    {
        private readonly IRepository<Entity.Domain.Roadmap.Roadmap> repository;
        private readonly IUnitOfWork unitOfWork;

        public RoadmapService(IRepository<Entity.Domain.Roadmap.Roadmap> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public ReturnModel<Entity.Domain.Roadmap.Roadmap> Create(Entity.Domain.Roadmap.Roadmap roadmapEntity)
        {
            var result = new ReturnModel<Entity.Domain.Roadmap.Roadmap>();
            
            try
            {
                if (roadmapEntity.Name != null /*userAuthentication*/)
                {
                    repository.Add(roadmapEntity);
                    result.Data = roadmapEntity;
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

        public ReturnModel<Entity.Domain.Roadmap.Roadmap> Update(Entity.Domain.Roadmap.Roadmap roadmapEntity)
        {
            var result = new ReturnModel<Entity.Domain.Roadmap.Roadmap>();

            try
            {
                repository.Update(roadmapEntity);
                result.Data = roadmapEntity;
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<IEnumerable<Entity.Domain.Roadmap.Roadmap>> GetAllByUser(int userId)
        {
            var result = new ReturnModel<IEnumerable<Entity.Domain.Roadmap.Roadmap>>();

            try
            {
                result.Data = repository.GetList(roadmap => roadmap.UserId == userId);
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<Entity.Domain.Roadmap.Roadmap> Get(int roadmapId)
        {
            var result = new ReturnModel<Entity.Domain.Roadmap.Roadmap>();

            try
            {
                result.Data = repository.Get(roadmap => roadmap.Id == roadmapId);
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<int> Delete(Entity.Domain.Roadmap.Roadmap roadmapEntity)
        {
            var result = new ReturnModel<int>();

            try
            {
                repository.Delete(roadmapEntity);
                result.Data = roadmapEntity.Id;
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
