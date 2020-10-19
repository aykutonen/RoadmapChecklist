using Entity.Models.Categories;
using Service.Roadmaps.CopiedRoadmaps.Models;
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
        ReturnModel<Category> Create(CopiedRoadmapViewModel copiedRoadmapViewModel);

    }
}
