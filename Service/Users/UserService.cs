using Data.Repository;
using Data.UnitOfWork;
using Entity.Models.Users;
using Service.Extensions;
using Service.Users.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace Service.Users
{
    public class UserService : IUserService
    {

        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;


        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public ReturnModel<User> Add(User userEntity)
        {
            var result = new ReturnModel<User>();

            try
            {
                userEntity.Password = userEntity.Password.MD5Hash();

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

        public User CheckUser(string email, string password)
        {
            password = password.MD5Hash();
            var user = _repository.Get(m => m.Email == email && m.Password == password);

            return user;
        }

        public ReturnModel<int> Delete(int userId)
        {
            var result = new ReturnModel<int>();

            try
            {
                _repository.Delete(userId);
                result.Data = userId;
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<User> Get(int userId)
        {
            var result = new ReturnModel<User>();

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

        public ReturnModel<IEnumerable<User>> GetAll()
        {
            var result = new ReturnModel<IEnumerable<User>>();

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

        public ReturnModel<User> Register(UserRegisterModel userRegisterModel)
        {
            var result = new ReturnModel<User>();
           
            try
            {
                // Todo : Use AutoMapper
                var user = new User()
                {
                    Email = userRegisterModel.Email,
                    Password = userRegisterModel.Password,
                    Name = userRegisterModel.Name,
                    Status = 1
                };

                Add(user);
                Save();

                result.Data = user;
            }
            catch (Exception ex)
            {

                result.IsSuccess=false;
                result.Exception = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public void Save()
        {
            _unitOfWork.Commmit();
        }

        public ReturnModel<User> Update(User userEntity)
        {
            var result = new ReturnModel<User>();

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




