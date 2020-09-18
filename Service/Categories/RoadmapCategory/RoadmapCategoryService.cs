using Data.Repository;
using Data.UnitOfWork;
using Entity.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Categories.RoadmapsCategory
{
    public class RoadmapCategoryService : IRoadmapCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<RoadmapCategory> _repository;

        public RoadmapCategoryService(IUnitOfWork unitOfWork,IRepository<RoadmapCategory> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Save()
        {
            _unitOfWork.Commmit();
        }

        public ReturnModel<RoadmapCategory> Add(RoadmapCategory roadmapCategory)
        {
            var result = new ReturnModel<RoadmapCategory>();
            try
            {
                _repository.Add(roadmapCategory);
                result.Data = roadmapCategory;

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<bool> Delete(int roadmapCategoryId)
        {
            var result = new ReturnModel<bool>();
            try
            {
                _repository.Delete(roadmapCategoryId);
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

        public ReturnModel<RoadmapCategory> Get(int roadmapCategoryId)
        {
            var result = new ReturnModel<RoadmapCategory>();
            try
            {
                _repository.Get(roadmapCategory=>roadmapCategory.Id==roadmapCategoryId);

            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<IEnumerable<RoadmapCategory>> GetAllByUser(int roadmapCategoryId)
        {
            var result = new ReturnModel<IEnumerable<RoadmapCategory>>();
            try
            {
                _repository.GetAll(roadmapCategory => roadmapCategory.Id == roadmapCategoryId);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<RoadmapCategory> Update(RoadmapCategory roadmapCategory)
        {
            var result = new ReturnModel<RoadmapCategory>();
            try
            {
                _repository.Update(roadmapCategory);
                result.Data = roadmapCategory;

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
