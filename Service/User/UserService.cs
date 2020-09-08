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

        public Entity.User CheckUser(string email, string password)
        {
            var user = _repository.Get(m => m.Email == email && m.Password == password);
            return user;
        }

        public void Save()
        {
            _unitOfWork.Commmit();
        }
    }
}




