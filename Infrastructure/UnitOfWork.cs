using Domains;
using System;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Infrastructure
{
    public class UnitOfWork<TContext> : IDisposable where TContext : DbContext, new()
    {
        private bool disposed = false;
        private TRepo GetRepo<TRepo, TEntity>() where TRepo : class
        {
            switch (typeof(TEntity).Name)
            {
                case "MainActivity": return new CachableRepository<MainActivity>(context) as TRepo;
                case "City": return new CachableRepository<City>(context) as TRepo;
                case "IndustrialCity": return new CachableRepository<IndustrialCity>(context) as TRepo;
                case "SubActivity": return new CachableRepository<SubActivity>(context) as TRepo;
                case "Role": return new CachableRepository<Role>(context) as TRepo;
                case "Permission": return new CachableRepository<Permission>(context) as TRepo;
                case "FacilitiesGroup": return new CachableRepository<FacilitiesGroup>(context) as TRepo;
                case "Facility": return new AuditableRepository<Facility>(context) as TRepo;
                default:
                    return null;
            }
        }
        private TContext context = new TContext();
        public IRepository<TEntity> Command<TEntity>() where TEntity : class, IBaseEntity
        {
            IRepository<TEntity> repo = GetRepo<Repository<TEntity>, TEntity>();
            if (repo == null) repo = new Repository<TEntity>(context);
            return repo;
        }

        public IReadRepository<TEntity> Query<TEntity>() where TEntity : class, IEntityKey
        {
            IReadRepository<TEntity> repo = GetRepo<ReadRepository<TEntity>, TEntity>();
            if (repo == null) repo = new ReadRepository<TEntity>(context);
            return repo;
        }

        public IEntityReadRepository<TEntity> QueryEntity<TEntity>() where TEntity : class, IBaseEntity
        {
            IEntityReadRepository<TEntity> repo = GetRepo<EntityReadRepository<TEntity>, TEntity>();
            if (repo == null) repo = new EntityReadRepository<TEntity>(context);
            return repo;
        }

        public IAuditableRepository<TEntity> AuditEntity<TEntity>() where TEntity : class, IAuditableEntity
        {
            IAuditableRepository<TEntity> repo = GetRepo<AuditableRepository<TEntity>, TEntity>();
            if (repo == null) repo = new AuditableRepository<TEntity>(context);
            return repo;
        }

        public int ExecuteSqlCommand(string sqlString, params SqlParameter[] sqlParameters)
        {
            return context.Database.ExecuteSqlCommand(sqlString, sqlParameters);
        }

        public void Save(ref IMDResponse res)
        {
            try { context.SaveChanges(); }
            catch (Exception ex) { res.Error(ex); }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
