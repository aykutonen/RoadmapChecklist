using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Repository
{
    public interface IRepository<T> :IDisposable where T :class 
    {
        T GetById(int id);
        T Get(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void Update(T entity);


        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

        void Delete(T entity);
        void Delete(int id);
        void Delete(Func<object, bool> p);

    
    }
}
