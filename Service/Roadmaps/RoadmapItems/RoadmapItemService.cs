using Data.Repository;
using Data.UnitOfWork;
using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.IRoadmapItem
{
    public class RoadmapItemService : IRoadmapItemService
    {

        public readonly IUnitOfWork unitOfWork;
        public readonly IRepository<Entity.RoadmapItem> repository;
        public RoadmapItemService(IUnitOfWork unitOfWork, IRepository<Entity.RoadmapItem> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;

        }

        public void Save()
        {
            unitOfWork.Commmit();
        }

        public ReturnModel<RoadmapItem> Add(RoadmapItem roadmapItem)
        {
            var result = new ReturnModel<Entity.RoadmapItem>();
            try
            {
                    repository.Add(roadmapItem);
                    result.Data = roadmapItem;

            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<int> Delete(int roadmapItem)
        {
            var result = new ReturnModel<int>();

            try
            {
                repository.Delete(roadmapItem);

                result.Data = roadmapItem.Id;
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<RoadmapItem> Get(int roadmapItemId)
        {

            var result = new ReturnModel<Entity.RoadmapItem>();
            try
            {
                result.Data = repository.Get(roadmap => roadmap.Id == roadmapItemId);
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<IEnumerable<RoadmapItem>> GetAllByUser(int userId)
        {
            var result = new ReturnModel<IEnumerable<Entity.RoadmapItem>>();
            try
            {
                result.Data = repository.GetAll(roadmap => roadmap.Id == userId);


            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<RoadmapItem> Update(RoadmapItem roadmapItem)
        {
            var result = new ReturnModel<Entity.RoadmapItem>();
            try
            {
                repository.Update(roadmapItem);
                result.Data = roadmapItem;

            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
