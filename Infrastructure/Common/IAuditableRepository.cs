using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public interface IAuditableRepository<TEntity> : IRepository<TEntity> where TEntity : class, IAuditableEntity
    {
        List<TEntity> GetAllVersions(long id,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, Object>>[] includeProperties);
    }
}
