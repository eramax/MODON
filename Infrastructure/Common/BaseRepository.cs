using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected DbContext context;
        protected IQueryable<TEntity> dbReadSet;
        protected DbSet<TEntity> dbSet;
        protected static List<TEntity> Entities;

        public BaseRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
            dbReadSet = dbSet;
        }
        protected IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> query,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null)
        {
            var rolefilter = RuleRepository<TEntity>.GetExpressions(CurrentUser.Role);
            if (rolefilter != null) query = query.Where(rolefilter);
            if (filter != null) query = query.Where(filter);
            if (orderBy != null) query = orderBy(query);
            if (skip.HasValue) query = query.Skip(skip.Value);
            if (take.HasValue) query = query.Take(take.Value);
            return query;
        }
    }
}
