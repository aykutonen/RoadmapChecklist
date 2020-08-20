using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Category
{
    public class CategoryService : ICategoryService
    {
        public readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }
 
        public void Add(Entity.Category category)
        {
            this._unitOfWork.GetRepository<Entity.Category>().Add(category);
        }

        public void Delete(int category)
        {
            this._unitOfWork.GetRepository<Entity.Category>().Delete(category);
        }

        public void Update(Entity.Category category)
        {
            this._unitOfWork.GetRepository<Entity.Category>().Update(category);
        }
    }
}
