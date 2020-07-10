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

        private bool disposed = false;


        public void Dispose()
        {

            GC.SuppressFinalize(this);
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new EfRepository<T>(_dbContext);
        }

        public int SaveChanges()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }

            ;
        }
    }
}
