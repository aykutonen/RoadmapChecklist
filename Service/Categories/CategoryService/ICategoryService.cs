using Entity.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Categories.CategoriesService
{
    public interface ICategoryService
    {
        ReturnModel<Category> Add(Category category);
        ReturnModel<Category> Update(Category category);
        ReturnModel<IEnumerable<Category>> GetAllByUser(int categoryId);
        ReturnModel<Category> Get(int categoryId);
        ReturnModel<bool> Delete(int categoryId);

        //void Add(Category category);
        //void Update(Category category);
        //void Delete(int category);
    }
}
