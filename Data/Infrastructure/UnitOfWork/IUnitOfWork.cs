using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
