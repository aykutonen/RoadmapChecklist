using Data.Repository;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;


namespace Service.User
{
    public class UserService : IUserService
    {

        private readonly IRepository<Entity.User> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public UserService(IRepository<Entity.User> repository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public ReturnModel<Entity.User> Add(Entity.User userEntity)
        {
            var result = new ReturnModel<Entity.User>();

            try
            {
                _repository.Add(userEntity);
                result.Data = userEntity;
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public Entity.User CheckUser(string email, string password)
        {
            var user = _repository.Get(m => m.Email == email && m.Password == password);
            return user;
        }

        public ReturnModel<int> Delete(Entity.User userEntity)
        {
            var result = new ReturnModel<int>();

            try
            {
                _repository.Delete(userEntity);
                result.Data = userEntity.Id;
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<Entity.User> Get(int userId)
        {
            var result = new ReturnModel<Entity.User>();

            try
            {
                result.Data = _repository.Get(user => user.Id == userId);
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<IEnumerable<Entity.User>> GetAll()
        {
            var result = new ReturnModel<IEnumerable<Entity.User>>();

            try
            {
                result.Data = _repository.GetAll();
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public void Save()
        {
            _unitOfWork.Commmit();
        }

        public ReturnModel<Entity.User> Update(Entity.User userEntity)
        {
            var result = new ReturnModel<Entity.User>();

            try
            {
                _repository.Update(userEntity);
                result.Data = userEntity;
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }
    }
}




