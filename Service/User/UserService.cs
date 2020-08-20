using Data.Repository;
using Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;


namespace Service.User
{
    public class UserService : IUserService
    {

        private readonly IRepository<Entity.User> repository;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IRepository<Entity.User> repository, IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
        }

        public void Create(Entity.User user)
        {
            repository.Add(user);
        }

        public void Delete(long id)
        {
            repository.Delete(long id);
        }

        public IEnumerable<Entity.User> Get()
        {
            return repository.GetAll();
        }

        public void Save()
        {
            unitOfWork.Commmit();
        }

        public void Update(Entity.User user)
        {
            repository.Update(user);
        }
    }
}




