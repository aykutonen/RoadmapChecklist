using Data.Repository;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Roadmap.Roadmap
{
    public class RoadmapService : IRoadmapService
    {
        public readonly IUnitOfWork unitOfWork;
        public readonly IRepository<Entity.Roadmap> repository;
        public RoadmapService(IUnitOfWork unitOfWork, IRepository<Entity.Roadmap> repository)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;

        }

        public void Save()
        {
            unitOfWork.Commmit();
        }

        ReturnModel<Entity.Roadmap> IRoadmapService.Add(Entity.Roadmap roadmapEntity)
        {
            var result = new ReturnModel<Entity.Roadmap>();
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

        ReturnModel<Entity.Roadmap> IRoadmapService.Update(Entity.Roadmap roadmapEntity)
        {
            var result = new ReturnModel<Entity.Roadmap>();
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

        public ReturnModel<IEnumerable<Entity.Roadmap>> GetAllByUser(int userId)
        {
            var result = new ReturnModel<IEnumerable<Entity.Roadmap>>();
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

        public ReturnModel<Entity.Roadmap> Get(int roadmapId)
        {
            var result = new ReturnModel<Entity.Roadmap>();
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

        public ReturnModel<int> Delete(int roadmapEntity)
        {
            var result = new ReturnModel<int>();

            try
            {
                repository.Delete(roadmapEntity);

                result.Data = roadmapEntity.Id;
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
