using Data.Infrastructure.Repository;
using Data.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;

namespace Service.Roadmap
{
    public class RoadmapService : IRoadmapService
    {
        private readonly IRepository<Entity.Roadmap> repository;
        private readonly IUnitOfWork unitOfWork;

        public RoadmapService(IRepository<Entity.Roadmap> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public ReturnModel<Entity.Roadmap> Create(Entity.Roadmap roadmap)
        {
            var result = new ReturnModel<Entity.Roadmap>();
            try
            {
                repository.Add(roadmap);
                Save();
                result.Data = roadmap;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Entity.Roadmap> Get(int id)
        {
            var result = new ReturnModel<Entity.Roadmap>();
            try
            {
                result.Data = repository.Get(id);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<List<Entity.Roadmap>> GetByUser(int userid)
        {
            var result = new ReturnModel<List<Entity.Roadmap>>();
            try
            {
                result.Data = repository.GetMany(x => x.UserId == userid);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Entity.Roadmap> Update(Entity.Roadmap roadmap)
        {
            var result = new ReturnModel<Entity.Roadmap>();
            try
            {
                repository.Update(roadmap);
                Save();
                result.Data = roadmap;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public void Save() => unitOfWork.Commit();
    }
}
