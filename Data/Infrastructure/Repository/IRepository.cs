using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Infrastructure.Repository
{
    public interface IRepository<T> where T:class , new()
    {
        T Get(Expression<Func<T,bool>> filter = null); //select by filter
        List<T> GetList(Expression<Func<T, bool>> filter = null); //return list if filter is applied
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
