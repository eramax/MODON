using Domains;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public class Repository<TEntity> : EntityReadRepository<TEntity>, IRepository<TEntity> where TEntity : class,IBaseEntity
    {
        public Repository(DbContext context) : base(context) { }

        public virtual TEntity Insert(TEntity entity, ref IMDResponse res)
        {
            if (!RuleRepository<TEntity>.IsValid(entity, ref res)) return null;
            try
            {
                entity.CreatedById = CurrentUser.UserId;
                entity.CreatedDate = DateTime.Now;
                var CanIDo = RuleRepository<TEntity>.ProcessModifiers(CurrentUser.Role, ref entity, true);
                if (!CanIDo) return null;
                dbSet.Add(entity);
                Entities = null;
            }
            catch (Exception ex) { res.Error(ex, entity); return null; }
            return entity;
        }
        public virtual TEntity Update(TEntity entity, ref IMDResponse res)
        {
            if (!RuleRepository<TEntity>.IsValid(entity, ref res) || !dbSet.Any(e => e.Id == entity.Id)) return null;
            try
            {
                entity.ModifiedDate = DateTime.Now;
                entity.ModifiedById = CurrentUser.UserId;
                entity.Version++;
                var CanIDo = RuleRepository<TEntity>.ProcessModifiers(CurrentUser.Role, ref entity,false);
                if (!CanIDo) return null;
                Attach(entity);
                Entities = null;
            }
            catch (Exception ex) {
                res.Error(ex, entity);
                return null;
            }
            return entity;
        }
        public virtual void InsertAndDelete(TEntity entity, ref IMDResponse res)
        {
            Insert(entity , ref res);
            Delete(entity, ref res);
        }
        public virtual void Insert(TEntity[] entities , ref IMDResponse res)
        {
            foreach (var t in entities) Insert(t, ref res);
        }

        public virtual void Delete(long? id, ref IMDResponse res)
        {
            if (id == null) return;
            var entityToDelete = dbSet.Find(id);
            if (entityToDelete == null) return;
            entityToDelete.DeletedById = CurrentUser.UserId;
            entityToDelete.DeletedDate = DateTime.Now;
            Update(entityToDelete, ref res);
        }
        public virtual void Delete(TEntity entity , ref IMDResponse res)
        {
            if (entity == null) return;
            entity.DeletedById = CurrentUser.UserId;
            entity.DeletedDate = DateTime.Now;
            Update(entity, ref res);
        }

        public virtual void Delete(Expression<Func<TEntity,bool>> filter , ref IMDResponse res) 
        {
            foreach (var x in Get(filter)) Delete(x.Id, ref res);
        }
        public virtual void HardDelete(long? id, ref IMDResponse res)
        {
            if (id == null) return;
            var entityToDelete = dbSet.Find(id);
            HardDelete(entityToDelete, ref res);
            Entities = null;
        }
        public virtual void HardDelete(TEntity entity , ref IMDResponse res)
        {
            try
            {
                if (context.Entry(entity).State == EntityState.Detached)
                {
                    dbSet.Attach(entity);
                }
                dbSet.Remove(entity);
                Entities = null;
            }
            catch (Exception ex) { res.Error(ex, entity); }
        }
        public virtual void Update(TEntity[] entitiesToUpdate , ref IMDResponse res)
        {
            foreach (var entity in entitiesToUpdate) Update(entity, ref res);
        }

        private void Attach(TEntity entity)
        {
            var local = dbSet.Local.FirstOrDefault(f => f.Id == entity.Id);
            if (local != null)
            {
                local = entity;
                context.Entry(local).State = EntityState.Modified;
            }
            else
            {
                dbSet.Attach(entity);
                context.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void UpdateAndDelete(TEntity entity , ref IMDResponse res)
        {
            Update(entity, ref res);
            Delete(entity, ref res);
        }
        public virtual TEntity AddOrUpdate(TEntity entity , ref IMDResponse res)
        {
            if (entity == null) return null;
            return dbSet.Any(e => e.Id == entity.Id) ? Update(entity, ref res) : Insert(entity, ref res);
        }
        public virtual TEntity MapAndSave<TSource>(TSource t , ref IMDResponse res) where TSource : IEntityKey
        {
            if (t == null) return null;
            if (dbSet.Any(e => e.Id == t.Id))
            {
                var entity = t.To(GetByID(t.Id));
                return Update(entity, ref res);
            }
            else
            {
                var entity = t.To<TEntity>();
                return Insert(entity, ref res);
            } 
        }
        public virtual TEntity MapAndSaveDiff<TSource>(TSource t , ref IMDResponse res) where TSource : IEntityKey
        {
            if (t == null) return null;
            if (dbSet.Any(e => e.Id == t.Id))
            {
                var entity = t.ToDiff(GetByID(t.Id));
                return Update(entity, ref res);
            }
            else
            {
                var entity = t.To<TEntity>();
                return Insert(entity, ref res);
            }
        }
        public virtual TEntity MapAndSaveAndDelete<TSource>(TSource t , ref IMDResponse res) where TSource : IEntityKey
        {
            if (t == null) return null;
            if (dbSet.Any(e => e.Id == t.Id))
            {
                var entity = t.To(GetByID(t.Id));
                UpdateAndDelete(entity, ref res);
                return entity;
            }
            else
            {
                var entity = t.To<TEntity>();
                InsertAndDelete(entity, ref res);
                return entity;
            }
        }
        public virtual TEntity MapAndInsert(object t , ref IMDResponse res)
        {
            if (t == null) return null;
            var entity = t.To<TEntity>();
            return Insert(entity, ref res);
        }
        public virtual void AddOrUpdate(TEntity[] entities , ref IMDResponse res)
        {
            foreach (var entity in entities) AddOrUpdate(entity, ref res);
        }
    }
}
