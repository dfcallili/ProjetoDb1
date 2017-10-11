using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Rh.Data.Contracts
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Include(string children);
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] properties);
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);
    }
}
