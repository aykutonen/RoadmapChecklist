using Data.UnitOfWork;
using Entity.Models.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tags
{
    public class TagService : ITagService
    {

        public readonly IUnitOfWork _unitOfWork;
        public TagService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public void Add(Tag tag)
        {
            this._unitOfWork.GetRepository<Tag>().Add(tag);
        }

        public void Delete(int tag)
        {
            this._unitOfWork.GetRepository<Tag>().Delete(tag);
        }

        public void Update(Tag tag)
        {
            this._unitOfWork.GetRepository<Tag>().Update(tag);
        }
    }
}
