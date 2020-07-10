using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure.UnitOfWork.EntityFramework
{
    public class EfUnitOfWorkBase : IUnitOfWork
    {
        private ApplicationDbContext dbContext;

        public EfUnitOfWorkBase(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Commit()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                //log ex
                throw ex;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbContext.Dispose();
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
        #endregion
    }
}
