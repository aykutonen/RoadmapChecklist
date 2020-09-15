using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Category
{
    public interface ICategoryService
    {
        void Add(Entity.Category category);
        void Update(Entity.Category category);
        void Delete(int category);
    }
}
