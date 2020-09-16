using Entity.Models.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tags
{
    public interface ITagService
    {
        void Add(Tag tag);
        void Update(Tag tag);
        void Delete(int tag);
    }
}
