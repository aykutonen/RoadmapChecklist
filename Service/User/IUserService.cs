using System;
using System.Collections.Generic;
using System.Text;
using Data.UnitOfWork;

namespace Service.User
{
    public interface IUserService : ISave
    {
        Entity.User CheckUser(string userName, string password);
    }
}
