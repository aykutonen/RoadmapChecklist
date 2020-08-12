using System;
using System.Collections.Generic;
using System.Text;

namespace Service.User
{
    public interface IUserService : ISave
    {
        ReturnModel<Entity.Domain.User.User> Create(Entity.Domain.User.User userEntity);
        ReturnModel<Entity.Domain.User.User> Update(Entity.Domain.User.User userEntity);
        ReturnModel<IEnumerable<Entity.Domain.User.User>> GetAll(); //IEnumarable & IQueryable ?
        ReturnModel<Entity.Domain.User.User> Get(int userId);
        ReturnModel<int> Delete(Entity.Domain.User.User userEntity);
    }
}
