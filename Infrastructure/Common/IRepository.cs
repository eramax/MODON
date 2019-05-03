using Domains;
using System;
using System.Linq.Expressions;

namespace Infrastructure
{
    public interface IRepository<TEntity>  : IEntityReadRepository<TEntity> where TEntity : class, IBaseEntity
    {
        TEntity Insert(TEntity entity, ref IMDResponse res);
        void Insert(TEntity[] entities , ref IMDResponse res);
        void Delete(long? id, ref IMDResponse res);
        void HardDelete(long? id, ref IMDResponse res);
        void Delete(TEntity entityToDelete, ref IMDResponse res);
        void Update(TEntity[] entitiesToUpdate, ref IMDResponse res);
        TEntity Update(TEntity entityToUpdate , ref IMDResponse res);
        TEntity AddOrUpdate(TEntity entity , ref IMDResponse res);
        void AddOrUpdate(TEntity[] entities, ref IMDResponse res);
        TEntity MapAndSave<TSource>(TSource t, ref IMDResponse res) where TSource : IEntityKey;
        TEntity MapAndSaveDiff<TSource>(TSource t, ref IMDResponse res) where TSource : IEntityKey;
        TEntity MapAndInsert(object t , ref IMDResponse res);
        void Delete(Expression<Func<TEntity, bool>> filter , ref IMDResponse res);
        TEntity MapAndSaveAndDelete<TSource>(TSource t , ref IMDResponse res) where TSource : IEntityKey;
        void UpdateAndDelete(TEntity entityToUpdate, ref IMDResponse res);
        void InsertAndDelete(TEntity entity, ref IMDResponse res);
    }
}
