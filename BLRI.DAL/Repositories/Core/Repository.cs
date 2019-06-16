using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using BLRI.DAL.Interfaces.Core;
using Microsoft.EntityFrameworkCore;

namespace BLRI.DAL.Repositories.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext Context;
        protected DbSet<T> DbSet;

        public Repository(ApplicationDbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
            #if DEBUG
                        //Context.Database.Log = s => Debug.WriteLine(s);
            #endif
        }

        public T Find(object id)
        {
            return DbSet.Find(id);
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            DbSet.AddRange(entities);
        }

        public void Remove(T entity)
        {
            DbSet.Remove(entity);
        }

        public void Remove(object id)
        {
            var entity = Find(id);
            if (entity != null)
                Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entites)
        {
            DbSet.RemoveRange(entites);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return orderBy?.Invoke(query).ToList() ?? query.ToList();
        }

        //public List<SelectItemViewModel<int>> AllForDropDownList()
        //{
        //    var result = DbSet
        //        .Where(d => d.IsArchived == false)
        //        .AsEnumerable()
        //        .Select(x => new SelectItemViewModel<int>
        //        {
        //            Id = x.Id,
        //            Name = x.Name
        //        }).ToList();

        //    return result;
        //}
    }
}
