using Data.Infrastructure.Repository;
using Data.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.RoadmapItem
{
    public class RoadmapItemService : IRoadmapItemService
    {
        private readonly IRepository<Entity.RoadmapItem> repository;
        private readonly IUnitOfWork unitOfWork;

        public RoadmapItemService(IRepository<Entity.RoadmapItem> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public ReturnModel<Entity.RoadmapItem> Create(Entity.RoadmapItem item)
        {
            var result = new ReturnModel<Entity.RoadmapItem>();
            try
            {
                repository.Add(item);
                Save();
                result.Data = item;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Entity.RoadmapItem> Get(int id)
        {
            var result = new ReturnModel<Entity.RoadmapItem>();
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

        public ReturnModel<List<Entity.RoadmapItem>> GetByRoadmap(int roadmapid)
        {
            var result = new ReturnModel<List<Entity.RoadmapItem>>();
            try
            {
                result.Data = repository.GetMany(x => x.RoadmapId == roadmapid, o => o.Id, true);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Entity.RoadmapItem> Update(Entity.RoadmapItem item)
        {
            var result = new ReturnModel<Entity.RoadmapItem>();
            try
            {
                repository.Update(item);
                Save();
                result.Data = item;
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
