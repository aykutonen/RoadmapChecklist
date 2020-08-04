using System;
using System.Collections.Generic;
using System.Text;
using Data.Context;
using Data.Repository;

namespace Data.UnitOfWork
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly RoadmapContext _dbContext;


        public UnitOfWork(RoadmapContext dbContext)
        {
            _dbContext = dbContext;


            //if (dbContext == null)
            //    throw new ArgumentNullException();
        }


        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EfRepository<T>(_dbContext);
        }

     

        public void Commmit()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }

        }


        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
