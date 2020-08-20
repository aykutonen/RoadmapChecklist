using System;
using System.Collections.Generic;
using System.Text;
using Data.UnitOfWork;


namespace Service.User
{
    public interface IUserService:ISave
    {
        void Create(Entity.User user);
        void Update(Entity.User user);
        IEnumerable<Entity.User> Get();
        void Delete(long id);
    }

}
