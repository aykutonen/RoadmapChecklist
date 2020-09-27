using System;
using System.Collections.Generic;
using System.Text;
using Data.UnitOfWork;
using Entity.Models.Users;
using Service.Users.Models;

namespace Service.Users
{
    public interface IUserService : ISave
    {
        ReturnModel<User> Add(User userEntity);
        ReturnModel<User> Update(User userEntity);
        ReturnModel<IEnumerable<User>> GetAll(); 
        ReturnModel<User> Get(int userId);
        ReturnModel<int> Delete(int userId);
        ReturnModel<User> Register(UserRegisterModel userRegisterModel);

        // Todo : Return type should be ReturnModel<T> class
        User CheckUser(string userName, string password);
        

        
    }
}
