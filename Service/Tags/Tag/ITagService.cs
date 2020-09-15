using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tag.Tag
{
    public interface ITagService
    {
        void Add(Entity.Tag tag);
        void Update(Entity.Tag tag);
        void Delete(int tag);
    }
}
