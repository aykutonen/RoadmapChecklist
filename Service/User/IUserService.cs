using System;
using System.Collections.Generic;
using System.Text;

namespace Service.User
{
    public interface IUserService : ISave
    {
        void Create(Entity.Domain.User.User userEntity);
        void Update(Entity.Domain.User.User userEntity);
        IEnumerable<Entity.Domain.User.User> Get();
        void Delete(int userId);
    }
}
