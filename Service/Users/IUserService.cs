using System;
using System.Collections.Generic;
using System.Text;
using Data.UnitOfWork;
using Entity.Models.Users;

namespace Service.Users
{
    public interface IUserService : ISave
    {
        ReturnModel<User> Add(User userEntity);
        ReturnModel<User> Update(User userEntity);
        ReturnModel<IEnumerable<User>> GetAll(); 
        ReturnModel<User> Get(int userId);
        ReturnModel<int> Delete(int userId);



        User CheckUser(string userName, string password);
    }
}
