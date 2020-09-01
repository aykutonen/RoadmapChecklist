using Data.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Infrastructure.UnitOfWork;
using Entity.Domain.User;

namespace Service.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Entity.Domain.User.User> repository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<Entity.Domain.User.User> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Save()
        {
            unitOfWork.Commit();
        }

        public ReturnModel<Entity.Domain.User.User> Create(Entity.Domain.User.User userEntity)
        {
            var result = new ReturnModel<Entity.Domain.User.User>();

            try
            {
                repository.Add(userEntity);
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

        public ReturnModel<Entity.Domain.User.User> Update(Entity.Domain.User.User userEntity)
        {
            var result = new ReturnModel<Entity.Domain.User.User>();

            try
            {
                repository.Update(userEntity);
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

        public ReturnModel<IEnumerable<Entity.Domain.User.User>> GetAll()
        {
            var result = new ReturnModel<IEnumerable<Entity.Domain.User.User>>();

            try
            {
                result.Data = repository.GetList();
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<Entity.Domain.User.User> Get(int userId)
        {
            var result = new ReturnModel<Entity.Domain.User.User>();

            try
            {
                result.Data = repository.Get(user => user.Id == userId);
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<int> Delete(Entity.Domain.User.User userEntity)
        {
            var result = new ReturnModel<int>();

            try
            {
                repository.Delete(userEntity);
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

        public ReturnModel<Entity.Domain.User.User> Register(Entity.Domain.User.User userEntity, string password)
        {
            var result = new ReturnModel<Entity.Domain.User.User>();
            byte[] passwordHash, passwordSalt;
            try
            {
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                userEntity.PasswordHash = passwordHash;
                userEntity.PasswordSalt = passwordSalt;

                repository.Add(userEntity);
                Save();

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

        public ReturnModel<Entity.Domain.User.User> Login(string userName, string password)
        {
            var result = new ReturnModel<Entity.Domain.User.User>();

            try
            {
                var userEntity = repository.Get(user => user.Name == userName);

                if (userEntity == null)
                {
                    result.Data = null;
                }
                else if (!VerifyPasswordHash(password, userEntity.PasswordHash, userEntity.PasswordSalt))
                {
                    result.Data = null;
                }
                else
                {
                    result.Data = userEntity;
                }
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        public ReturnModel<bool> IsUserExist(string userName)
        {
            var result = new ReturnModel<bool>();
            try
            {
                var userEntity = repository.Get(user => user.Name == userName);
                if (userEntity != null)
                {
                    result.Data = true;
                }
                else
                {
                    result.Data = false;
                }
            }
            catch (Exception exception)
            {
                result.IsSuccess = false;
                result.Exception = exception;
                result.Message = exception.Message;
            }

            return result;
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (var i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        private void CreatePasswordHash(string userEntityPassword, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(userEntityPassword));
            }
        }
    }
}
