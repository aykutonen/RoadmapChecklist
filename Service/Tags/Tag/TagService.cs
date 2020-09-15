using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tag.Tag
{
    public class TagService : ITagService
    {

        public readonly IUnitOfWork _unitOfWork;
        public TagService(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
        }

        public void Add(Entity.Tag tag)
        {
            this._unitOfWork.GetRepository<Entity.Tag>().Add(tag);
        }

        public void Delete(int tag)
        {
            this._unitOfWork.GetRepository<Entity.Tag>().Delete(tag);
        }

        public void Update(Entity.Tag tag)
        {
            this._unitOfWork.GetRepository<Entity.Tag>().Update(tag);
        }
    }
}
