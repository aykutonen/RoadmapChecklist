using Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Infrastructure.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T Get(int id, params string[] navigations);
        T Get(Expression<Func<T, bool>> where,
           Expression<Func<T, object>> orderBy = null,
          bool isOrderByAsc = false,
           params string[] navigations);
        List<T> GetMany(Expression<Func<T, bool>> where,
            Expression<Func<T, object>> orderBy = null,
            bool isOrderByAsc = false,
            params string[] navigations);
    }
}
