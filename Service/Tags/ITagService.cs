using Entity.Models.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tags
{
    public interface ITagService
    {
        ReturnModel<Tag> Add(Tag tag);
        ReturnModel<Tag> Update(Tag tag);
        ReturnModel<IEnumerable<Tag>> GetAllByUser(int tagId);
        ReturnModel<Tag> Get(int tagId);
        ReturnModel<bool> Delete(int tagId);
        //void Add(Tag tag);
        //void Update(Tag tag);
        //void Delete(int tag);
    }
}
