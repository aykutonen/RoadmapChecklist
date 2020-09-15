using System;
using System.Collections.Generic;
using System.Text;
using Data.UnitOfWork;

namespace Service.User
{
    public interface IUserService : ISave
    {
        ReturnModel<Entity.User> Add(Entity.User userEntity);
        ReturnModel<Entity.User> Update(Entity.User userEntity);
        ReturnModel<IEnumerable<Entity.User>> GetAll(); 
        ReturnModel<Entity.User> Get(int userId);
        ReturnModel<int> Delete(Entity.User userEntity);



        Entity.User CheckUser(string userName, string password);
    }
}
