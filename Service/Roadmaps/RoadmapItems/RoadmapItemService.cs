using Data.Repository;
using Data.UnitOfWork;
using Entity;
using Entity.Models.Roadmaps;
using Service.Roadmaps.RoadmapItems.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmaps.IRoadmapItems
{
    public class RoadmapItemService : IRoadmapItemService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<RoadmapItem> _repository;
        public RoadmapItemService(IUnitOfWork unitOfWork, IRepository<RoadmapItem> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Save()
        {
            _unitOfWork.Commmit();
        }

        public ReturnModel<RoadmapItem> Add(RoadmapItem roadmapItem)
        {
            var result = new ReturnModel<RoadmapItem>();
            try
            {
                _repository.Add(roadmapItem);
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

        public ReturnModel<int> Delete(int roadmapItemId)
        {
            var result = new ReturnModel<int>();

            try
            {
                _repository.Delete(roadmapItemId);
                result.Data = roadmapItemId;
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

            var result = new ReturnModel<RoadmapItem>();
            try
            {
                result.Data = _repository.Get(roadmap => roadmap.Id == roadmapItemId);
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
            var result = new ReturnModel<IEnumerable<RoadmapItem>>();
            try
            {
                result.Data = _repository.GetAll(roadmap => roadmap.Id == userId);


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
            var result = new ReturnModel<RoadmapItem>();
            try
            {
                _repository.Update(roadmapItem);
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

        public ReturnModel<RoadmapItem> Create(RoadmapItemViewModel roadmapItemViewModel)
        {
            var result = new ReturnModel<RoadmapItem>();
            try
            {
                var roadmapItem = new RoadmapItem()
                {
                    Title = roadmapItemViewModel.Title,
                    Description = roadmapItemViewModel.Description,
                    TargetEndDate = roadmapItemViewModel.TargetEndDate,
                    EndDate = roadmapItemViewModel.EndDate,
                    RoadmapId = roadmapItemViewModel.RoadmapId,
                    Status = 1,
                    ParentId = roadmapItemViewModel.ParentId
                };

                Add(roadmapItem);
                Save();

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

        public ReturnModel<RoadmapItem> UpdateItem(RoadmapItemViewModel roadmapItemViewModel)
        {
            var result = new ReturnModel<RoadmapItem>();

            try
            {
                var updateRoadmapItem = new RoadmapItem()
                {
                    Title = roadmapItemViewModel.Title,
                    Description = roadmapItemViewModel.Description,
                    TargetEndDate = roadmapItemViewModel.TargetEndDate,
                    EndDate = roadmapItemViewModel.EndDate,
                    RoadmapId = roadmapItemViewModel.RoadmapId,
                    Status = 1,
                    ParentId = roadmapItemViewModel.ParentId
                };

                Add(updateRoadmapItem);
                Save();

                result.Data = updateRoadmapItem;
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

