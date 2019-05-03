using Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class EntityReadRepository<TEntity> : BaseRepository<TEntity>, IEntityReadRepository<TEntity> 
        where TEntity : class, IBaseEntity
    {
        public EntityReadRepository(DbContext context) : base(context) { }

        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            var query = ApplyFilterOnEntity(dbReadSet, filter, null, includeProperties, false, null, null);
            return query.ToList();
        }

        public virtual List<TResult> Get<TResult>(Expression<Func<TEntity, bool>> filter,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
              return  Get(filter, null, false, null, null, includeProperties).To<List<TResult>>();
        }


        public virtual List<TEntity> Get(params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            var query =
                ApplyFilterOnEntity(dbReadSet, null, null, includeProperties, false, null, null);
            return query.ToList();
        }

        public virtual List<TResult> Get<TResult>(params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            return Get(null, null, false, null, null, includeProperties).To<List<TResult>>();
        }

        public virtual List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false, int? skip = null, int? take = null,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            var query =
                ApplyFilterOnEntity(dbReadSet, filter, orderBy, includeProperties, includeDeleted, skip, take);
            return query.ToList();
        }

        public virtual List<TResult> Get<TResult>(Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,bool includeDeleted = false, int? skip = null, int? take = null,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            return Get(filter, orderBy, includeDeleted, skip, take, includeProperties).To<List<TResult>>(); 
        }

        public virtual List<TResult> GetListFiltered<TResult>(List<Expression<Func<TEntity, bool>>> filter, params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            return GetListFiltered(filter, null, false, null, null, includeProperties).To<List<TResult>>(); 
        }
        public virtual List<TEntity> GetListFiltered(List<Expression<Func<TEntity, bool>>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,bool includeDeleted = false, int? skip = null, int? take = null,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            var query = ApplyFilterOnEntityFilterList(dbReadSet, filter, orderBy, includeProperties, includeDeleted, skip, take);
            return query.ToList();
        }

        public virtual List<TResult> GetListFiltered<TResult>(List<Expression<Func<TEntity, bool>>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,bool includeDeleted = false, int? skip = null, int? take = null,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            return GetListFiltered(filter, orderBy, includeDeleted, skip, take, includeProperties).To<List<TResult>>();
        }

        public virtual TEntity GetByID(long? id,bool includeDeleted = false,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            if (id == null) return null;
            var query =
                      ApplyFilterOnEntity(dbReadSet, x => x.Id == id, null, includeProperties, includeDeleted);
            return query.FirstOrDefault();
        }

        public virtual TResult GetByID<TResult>(long? id,bool includeDeleted = false,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            return GetByID(id, includeDeleted, includeProperties).To<TResult>();

        }
        protected IQueryable<TEntity> ExcludeDeleted(IQueryable<TEntity> query, bool includeDeleted = false)
        {
            return includeDeleted ? query : query.Where(x => x.DeletedDate == null);
        }

        protected IQueryable<TEntity> Includes(IQueryable<TEntity> query, params Expression<Func<TEntity, object>>[] paths)
        {
            return paths.Data().Aggregate(query, (current, path) => current.Include(path));
        }

        public virtual List<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> properities,Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false, int? skip = null, int? take = null,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            return ApplyFilterOnEntity(dbReadSet, filter, orderBy,includeProperties,includeDeleted, skip, take).Select(properities).ToList();
        }

        public virtual List<object> Select(Expression<Func<TEntity, object>> properities,Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,bool includeDeleted = false, int? skip = null, int? take = null,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            return ApplyFilterOnEntity(dbReadSet, filter, orderBy, includeProperties, includeDeleted, skip, take).Select(properities).ToList<Object>();
        }

        public virtual TResult SelectSingle<TResult>(Expression<Func<TEntity, TResult>> properities,Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,bool includeDeleted = false, int? skip = null, int? take = null,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            return ApplyFilterOnEntity(dbReadSet, filter, orderBy, includeProperties, includeDeleted, skip, take).Select(properities).FirstOrDefault();
        }

        public virtual object SelectSingle(Expression<Func<TEntity, object>> properities,Expression<Func<TEntity, bool>> filter = null,Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,bool includeDeleted = false, int? skip = null, int? take = null,params Expression<Func<TEntity, Object>>[] includeProperties)
        {
            return ApplyFilterOnEntity(dbReadSet, filter, orderBy, includeProperties, includeDeleted, skip, take).Select(properities).FirstOrDefault();
        }

        public long Count(Expression<Func<TEntity, bool>> filter = null, bool includeDeleted = false)
        {
            return ApplyFilterOnEntity(dbReadSet, filter , null,null, includeDeleted, null,null).Count();
        }

        protected IQueryable<TEntity> ApplyFilterOnEntity(IQueryable<TEntity> query,
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            Expression<Func<TEntity, object>>[] includeProperties,
            bool includeDeleted, int? skip = null, int? take = null)
        {
            if (includeProperties != null) query = dbSet;
            query = ApplyFilter(query, filter, orderBy, skip, take);
            query = ExcludeDeleted(query, includeDeleted);
            query = Includes(query, includeProperties);
            return query;
        }

        protected IQueryable<TEntity> ApplyFilterOnEntityFilterList(IQueryable<TEntity> query,
            List<Expression<Func<TEntity, bool>>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            Expression<Func<TEntity, object>>[] includeProperties,
            bool includeDeleted, int? skip = null, int? take = null)
        {
            if (includeProperties != null) query = dbSet;
            query = ApplyFilter(query, null, orderBy, skip, take);
            if(filter != null) foreach(var fn in filter) query = query.Where(fn);
            query = ExcludeDeleted(query, includeDeleted);
            query = Includes(query, includeProperties);
            return query;
        }

        public List<TEntity> GetByIDs(long[] ids, bool includeDeleted = false, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            if (ids == null || !ids.Any()) return null;
            var query =  ApplyFilterOnEntity(dbReadSet, x => ids.Contains(x.Id), null, includeProperties, includeDeleted);
            return query.ToList();
        }

        public List<TResult> GetByIDs<TResult>(long[] ids, bool includeDeleted = false, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return GetByIDs(ids, includeDeleted, includeProperties).To<List<TResult>>(); 
        }
        public List<long> GetIDs(Expression<Func<TEntity, bool>> filter)
        {
            return Select(x => x.Id, filter);
        }

    }
}
