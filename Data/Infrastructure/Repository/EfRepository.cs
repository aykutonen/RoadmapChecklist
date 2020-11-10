using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Infrastructure.Repository
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public EfRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = this.dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public T Get(int id, params string[] navigations)
        {
            var set = dbSet.AsQueryable();
            foreach (string nav in navigations) { set = set.Include(nav); }
            return set.FirstOrDefault(x => x.Id == id);
        }

        public T Get(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy = null, bool isOrderByAsc = false, params string[] navigations)
        {
            var set = dbSet.AsQueryable();
            foreach (string nav in navigations) { set = set.Include(nav); }
            set = set.Where(where);
            if (orderBy != null) { set = isOrderByAsc ? set.OrderBy(orderBy) : set.OrderByDescending(orderBy); }
            return set.FirstOrDefault();
        }

        public IEnumerable<T> GetMany(Expression<Func<T, bool>> where, Expression<Func<T, object>> orderBy = null, bool isOrderByAsc = false, params string[] navigations)
        {
            var set = dbSet.AsQueryable();
            foreach (string nav in navigations) { set = set.Include(nav); }
            set = set.Where(where);
            if (orderBy != null) { set = isOrderByAsc ? set.OrderBy(orderBy) : set.OrderByDescending(orderBy); }
            return set.ToList();
        }


    }
}
