using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public interface IEntityReadRepository<TEntity> where TEntity : class, IBaseEntity
    {
        List<TEntity> Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, Object>>[] includeProperties);
        List<TResult> Get<TResult>(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, Object>>[] includeProperties);
        List<TEntity> Get(params Expression<Func<TEntity, Object>>[] includeProperties);
        List<TResult> Get<TResult>(params Expression<Func<TEntity, Object>>[] includeProperties);
        List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false, int? skip = null, int? take = null, params Expression<Func<TEntity, Object>>[] includeProperties);
        List<TResult> Get<TResult>(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false, int? skip = null, int? take = null, params Expression<Func<TEntity, Object>>[] includeProperties);
        List<TResult> GetListFiltered<TResult>(List<Expression<Func<TEntity, bool>>> filter, params Expression<Func<TEntity, Object>>[] includeProperties);
        List<TEntity> GetListFiltered(List<Expression<Func<TEntity, bool>>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false, int? skip = null, int? take = null, params Expression<Func<TEntity, Object>>[] includeProperties);
        List<TResult> GetListFiltered<TResult>(List<Expression<Func<TEntity, bool>>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false, int? skip = null, int? take = null, params Expression<Func<TEntity, Object>>[] includeProperties);
        TEntity GetByID(long? id, bool includeDeleted = false, params Expression<Func<TEntity, Object>>[] includeProperties);
        TResult GetByID<TResult>(long? id, bool includeDeleted = false, params Expression<Func<TEntity, Object>>[] includeProperties);
        List<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> properities, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false, int? skip = null, int? take = null, params Expression<Func<TEntity, Object>>[] includeProperties);
        List<Object> Select(Expression<Func<TEntity, Object>> properities, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false, int? skip = null, int? take = null, params Expression<Func<TEntity, Object>>[] includeProperties);
        TResult SelectSingle<TResult>(Expression<Func<TEntity, TResult>> properities, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false, int? skip = null, int? take = null, params Expression<Func<TEntity, Object>>[] includeProperties);
        Object SelectSingle(Expression<Func<TEntity, Object>> properities, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, bool includeDeleted = false, int? skip = null, int? take = null, params Expression<Func<TEntity, Object>>[] includeProperties);
        long Count(Expression<Func<TEntity, bool>> filter = null, bool includeDeleted = false);
        List<TEntity> GetByIDs(long[] ids, bool includeDeleted = false, params Expression<Func<TEntity, Object>>[] includeProperties);
        List<TResult> GetByIDs<TResult>(long[] ids, bool includeDeleted = false, params Expression<Func<TEntity, Object>>[] includeProperties);
        List<long> GetIDs(Expression<Func<TEntity, bool>> filter);
    }
}
