using Data.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Infrastructure.UnitOfWork;

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
            throw new NotImplementedException();
        }

        public void Create(Entity.Domain.User.User userEntity)
        {
            throw new NotImplementedException();
        }

        public void Update(Entity.Domain.User.User userEntity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity.Domain.User.User> Get()
        {
            throw new NotImplementedException();
        }

        public void Delete(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
