using Entity.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Categories.CategoriesService
{
    public interface ICategoryService
    {
        void Add(Category category);
        void Update(Category category);
        void Delete(int category);
    }
}
