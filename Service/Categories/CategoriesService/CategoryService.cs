using Data.Repository;
using Data.UnitOfWork;
using Entity.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Categories.CategoriesService
{
    public class CategoryService : ICategoryService
    {

        private readonly IRepository<Category> _repository;
        public readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork,IRepository<Category> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
 
        public void Add(Category category)
        {
            this._unitOfWork.GetRepository<Category>().Add(category);
        }

        public void Delete(int category)
        {
            this._unitOfWork.GetRepository<Category>().Delete(category);
        }

        public void Update(Category category)
        {
            this._unitOfWork.GetRepository<Category>().Update(category);
        }
    }
}
