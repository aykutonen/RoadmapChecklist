using Data.Repository;
using Data.UnitOfWork;
using Entity.Models.Tags;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Tags
{
    public class TagService : ITagService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Tag> _repository;
        public TagService(IUnitOfWork unitOfWork,IRepository<Tag> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public ReturnModel<Tag> Add(Tag tag)
        {
            var result = new ReturnModel<Tag>();
            try
            {
                _repository.Add(tag);
                result.Data = tag;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<bool> Delete(int tagId)
        {
            var result = new ReturnModel<bool>();
            try
            {
                _repository.Delete(tagId);
                result.Data = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<Tag> Get(int tagId)
        {
            var result = new ReturnModel<Tag>();
            try
            {
                result.Data = _repository.Get(tag=>tag.Id==tagId);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public ReturnModel<IEnumerable<Tag>> GetAllByUser(int tagId)
        {
            var result = new ReturnModel<IEnumerable<Tag>>();
            try
            {
                result.Data = _repository.GetAll(tag=>tag.Id==tagId);
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }

        public void Save()
        {
            _unitOfWork.Commmit();
        }

        public ReturnModel<Tag> Update(Tag tag)
        {
            var result = new ReturnModel<Tag>();
            try
            {
                _repository.Update(tag);
                result.Data = tag;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
