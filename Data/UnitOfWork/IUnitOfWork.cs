using System;
using System.Collections.Generic;
using System.Text;
using Data.Repository;

namespace Data.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
       
        void Commmit();
    }
}
