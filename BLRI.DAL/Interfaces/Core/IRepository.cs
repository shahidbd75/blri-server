using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BLRI.DAL.Interfaces.Core
{
    public interface IRepository<T> where T : class
    {
        T Find(object id);
        T Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(object id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entites);
        void Update(T entity);

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
    }
}
