using Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class AuditableRepository<TEntity> : Repository<TEntity> , IAuditableRepository<TEntity> 
        where TEntity : class, IAuditableEntity
    {
        public AuditableRepository(DbContext context) : base(context) { }
        public override TEntity Insert(TEntity entity, ref IMDResponse res)
        {
            if(string.IsNullOrEmpty(entity.Ref)) entity.Ref = Guid.NewGuid().ToString();
            return base.Insert(entity, ref res);
        }
        public override TEntity Update(TEntity entity , ref IMDResponse res)
        {
            if (entity == null || !dbSet.Any(e => e.Id == entity.Id)) return null;
            {
                var old = dbSet.AsNoTracking().FirstOrDefault(e => e.Id == entity.Id);
                old.Id = 0;
                old.DeletedDate = DateTime.Now;
                old.DeletedById = CurrentUser.UserId;
                Insert(old, ref res);
                entity.Ref = old.Ref;
                return base.Update(entity, ref res);
            }
        }

        public List<TEntity> GetAllVersions(long id,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            var entity = GetByID(id);
            var query = ApplyFilterOnEntity(dbSet, filter, orderBy, includeProperties, true).Where(x => x.Ref == entity.Ref);
            return query.ToList();
        }
    }
}
