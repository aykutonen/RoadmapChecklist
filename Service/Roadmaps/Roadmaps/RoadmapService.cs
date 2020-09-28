
using Data.Repository;
using Data.UnitOfWork;
using Entity.Models.Roadmaps;
using Service.Roadmaps.Roadmaps.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmaps.Roadmaps
{
    public class RoadmapService : IRoadmapService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Roadmap> _repository;
        public RoadmapService(IUnitOfWork unitOfWork, IRepository<Roadmap> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;

        }

        public void Save()
        {
            _unitOfWork.Commmit();
        }

        public ReturnModel<Roadmap> Add(Roadmap roadmapEntity)
        {
            var result = new ReturnModel<Roadmap>();
            try
            {
                if (roadmapEntity.Name != null)
                {
                    _repository.Add(roadmapEntity);
                    result.Data = roadmapEntity;

                }

            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Roadmap> Update(Roadmap roadmapEntity)
        {
            var result = new ReturnModel<Roadmap>();
            try
            {
                _repository.Update(roadmapEntity);
                result.Data = roadmapEntity;

            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<IEnumerable<Roadmap>> GetAllByUser(int userId)
        {
            var result = new ReturnModel<IEnumerable<Roadmap>>();
            try
            {
                result.Data = _repository.GetAll(roadmapEntity => roadmapEntity.Id == userId);
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Roadmap> Get(int roadmapId)
        {
            var result = new ReturnModel<Roadmap>();
            try
            {
                result.Data = _repository.Get(roadmap => roadmap.Id == roadmapId);

            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<bool> Delete(int roadmapId)
        {
            var result = new ReturnModel<bool>();

            try
            {
                _repository.Delete(roadmapId);
                result.Data = true;
            }
            catch (Exception ex)
            {
                result.Data = false;
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }
        public ReturnModel<Roadmap> AddRoadmap(RoadmapViewModel roadmapViewModel)
        {
            var result = new ReturnModel<Roadmap>();

            try
            {
                // Todo : Use AutoMapper
                var roadmap = new Roadmap()
                {
                    Name = roadmapViewModel.Name,
                    Visibility = roadmapViewModel.Visibility,
                    EndDate=roadmapViewModel.EndDate,
                    StartDate=roadmapViewModel.StartDate,
                    UserId=roadmapViewModel.UserId,
                    Status = 1
                };

                Add(roadmap);
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
    }
}
