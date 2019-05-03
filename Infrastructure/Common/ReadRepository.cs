using Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class ReadRepository<TEntity> : BaseRepository<TEntity>, IReadRepository<TEntity> where TEntity : class , IEntityKey
    {
        public ReadRepository(DbContext context) : base(context) { }
        public virtual List<TEntity> Get(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
        int? skip = null, int? take = null) 
        {
            return ApplyFilter(dbReadSet, filter, orderBy, skip, take).ToList();
        }

        public virtual TEntity GetByID(long? id)
        {
            return id == null ? null : ApplyFilter(dbReadSet, x => x.Id == id).FirstOrDefault();
        }

        public List<TEntity> Exec(string sql, params SqlParameter[] parameters)
        {
            try
            {
                return context.Database.SqlQuery<TEntity>(sql, parameters).ToList();
            }
            catch(Exception ex) { MDResponse.CallErrorHandlers(ex, sql);  return null; }
        }

        public List<TEntity> ExecStoredProcedure(string storedProcedureName, params SqlParameter[] parameters)
        {
            return context.Database.SqlQuery<TEntity>("EXEC " + storedProcedureName + " ", parameters).ToList();
        }

        protected DbQuery<TEntity> QuerySet() 
        {
            return context.Set<TEntity>().AsNoTracking();
        }
        public long Count(Expression<Func<TEntity, bool>> filter = null)
        {
            return ApplyFilter(dbReadSet, filter).Count();
        }

        public virtual List<TResult> Select<TResult>(Expression<Func<TEntity, TResult>> properities,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null, int? take = null)
        {
            return ApplyFilter(dbReadSet, filter, orderBy, skip, take).Select(properities).ToList();
        }
    }
}
