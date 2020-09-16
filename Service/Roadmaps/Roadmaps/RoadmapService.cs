using Data.Repository;
using Data.UnitOfWork;
using Entity.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmaps.Roadmaps
{
    public class RoadmapService : IRoadmapService
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IRepository<Roadmap> repository;
        public RoadmapService(IUnitOfWork unitOfWork, IRepository<Roadmap> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;

        }

        public void Save()
        {
            unitOfWork.Commmit();
        }

        ReturnModel<Roadmap> IRoadmapService.Add(Roadmap roadmapEntity)
        {
            var result = new ReturnModel<Roadmap>();
            try
            {
                if (roadmapEntity.Name != null)
                {
                    repository.Add(roadmapEntity);
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

        ReturnModel<Roadmap> IRoadmapService.Update(Roadmap roadmapEntity)
        {
            var result = new ReturnModel<Roadmap>();
            try
            {
                repository.Update(roadmapEntity);
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

        public ReturnModel<Roadmap> Get(int roadmapId)
        {
            var result = new ReturnModel<Roadmap>();
            try
            {
                result.Data = repository.Get(roadmap => roadmap.Id == roadmapId);
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
                repository.Delete(roadmapId);
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

     
    }
}
