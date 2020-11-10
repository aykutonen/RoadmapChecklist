using System;
using System.Collections.Generic;
using System.Text;

namespace Service.User
{
    public interface IUserService : ISave
    {
        ReturnModel<Entity.User> Create(Entity.User user);
        ReturnModel<Entity.User> Update(Entity.User user);
        ReturnModel<Entity.User> Get(int id);
        ReturnModel<List<Entity.User>> Get();
    }
}
