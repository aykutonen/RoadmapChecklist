using Data.Repository;
using Data.UnitOfWork;
using Entity.Models.Roadmaps;
using System;
using System.Collections.Generic;
using System.Text;


namespace Service.Roadmaps.CopiedRoadmaps
{
    public class CopiedRoadmapService : ICopiedRoadmapService
    {
       
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CopiedRoadmap> _repository;
        public CopiedRoadmapService(IUnitOfWork unitOfWork,IRepository<CopiedRoadmap> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Save()
        {
            _unitOfWork.Commmit();
        }

        public ReturnModel<CopiedRoadmap> Add(CopiedRoadmap copiedRoadmap)
        {
            var result = new ReturnModel<CopiedRoadmap>();
            try
            {
                    _repository.Add(copiedRoadmap);
                    result.Data = copiedRoadmap;
            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<bool> Delete(int copiedRoadmapId)
        {
            var result = new ReturnModel<bool>();
            try
            {
                _repository.Delete(copiedRoadmapId);
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

        public ReturnModel<CopiedRoadmap> Get(int copiedRoadmapId)
        {
            var result = new ReturnModel<CopiedRoadmap>();
            try
            {
                result.Data = _repository.Get(copiedRoadmap => copiedRoadmap.Id==copiedRoadmapId);

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<IEnumerable<CopiedRoadmap>> GetAllByUser(int copiedRoadmapId)
        {
            var result = new ReturnModel<IEnumerable<CopiedRoadmap>>();
            try
            {
                result.Data = _repository.GetAll(copiedRoadmap => copiedRoadmap.Id == copiedRoadmapId);


            }
            catch (Exception ex)
            {

                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<CopiedRoadmap> Update(CopiedRoadmap copiedRoadmap)
        {
            var result = new ReturnModel<CopiedRoadmap>();
            try
            {
                _repository.Update(copiedRoadmap);
                result.Data = copiedRoadmap;

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
