using Data.Infrastructure.Repository;
using Data.Infrastructure.UnitOfWork;
using System;

namespace Service.User
{
    public class UserService : IUserService
    {
        private readonly IRepository<Entity.User> repository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<Entity.User> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public ReturnModel<Entity.User> Create(Entity.User user)
        {
            var result = new ReturnModel<Entity.User>();
            try
            {
                repository.Add(user);
                Save();
                result.Data = user;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public ReturnModel<Entity.User> Update(Entity.User user)
        {
            var result = new ReturnModel<Entity.User>();
            try
            {
                repository.Update(user);
                Save();
                result.Data = user;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.Exception = ex;
                result.Message = ex.Message;
            }

            return result;
        }

        public ReturnModel<Entity.User> Get(int id)
        {
            var result = new ReturnModel<Entity.User>();
            try
            {
                result.Data = repository.Get(id);
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
            unitOfWork.Commit();
        }

    }
}
