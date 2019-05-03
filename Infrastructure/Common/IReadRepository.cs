using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public interface IReadRepository<TEntity> where TEntity : class
    {
        List<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null);

        TEntity GetByID(long? id);

        List<TEntity> Exec(string sql, params SqlParameter[] parameters);

        List<TEntity> ExecStoredProcedure(string storedProcedureName, params SqlParameter[] parameters);

        long Count(Expression<Func<TEntity, bool>> filter = null);

        List<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> properities,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null);
    }
}
