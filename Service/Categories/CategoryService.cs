using Data.Repository;
using Data.UnitOfWork;
using Entity.Models.Categories;
using Service.Roadmaps.CopiedRoadmaps.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Categories.CategoriesService
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork,IRepository<Category> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public void Save()
        {
            _unitOfWork.Commmit();
        }

        public ReturnModel<Category> Add(Category category)
        {
            var result = new ReturnModel<Category>();
            try
            {
                _repository.Add(category);
                result.Data = category;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;

            }
            return result;
        }

        public ReturnModel<Category> Update(Category category)
        {
            var result = new ReturnModel<Category>();
            try
            {
                _repository.Update(category);
                result.Data = category;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<IEnumerable<Category>> GetAllByUser(int categoryId)
        {
            var result = new ReturnModel<IEnumerable<Category>>();
            try
            {
                _repository.GetAll(category => category.Id == categoryId);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Category> Get(int categoryId)
        {
            var result = new ReturnModel<Category>();
            try
            {
                _repository.Get(category=>category.Id==categoryId);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<bool> Delete(int categoryId)
        {
            var result = new ReturnModel<bool>();
            try
            {
                _repository.Delete(categoryId);
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

        public ReturnModel<Category> Create(CopiedRoadmapViewModel copiedRoadmapViewModel)
        {
            throw new NotImplementedException();
        }

    
    }
}
