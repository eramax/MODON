using Domains;
using System;
using Infrastructure;

namespace Commands
{
    public interface ISaveService<TEntity, TViewModel>
    where TEntity : IBaseEntity, new()
    where TViewModel : class, IEntityKey, new()
    {
        TEntity Save(TViewModel vm, ref IMDResponse res);
        void Delete(long? id, ref IMDResponse res);
    }

    public class BasicService
    {
        public static TEntity SaveEntity<TEntity>(IEntityKey t , ref IMDResponse res) where TEntity : class, IBaseEntity
        {
            UnitWork uw = new UnitWork();
            var x = uw.Command<TEntity>().MapAndSave(t, ref res);
            uw.Save(ref res);
            return x;
        }
        public static void SoftDeleteEntity<TEntity>(long? id, ref IMDResponse res) where TEntity : class, IBaseEntity
        {
            UnitWork uw = new UnitWork();
            uw.Command<TEntity>().Delete(id , ref res);
            uw.Save(ref res);
        }
    }

    public class BasicService<TEntity, TViewModel> : ISaveService<TEntity, TViewModel>
    where TEntity : class, IBaseEntity, new()
    where TViewModel : class, IEntityKey, new()
    {
        public UnitWork uw { get; set; } = new UnitWork();
        public virtual TEntity Save(TViewModel t, ref IMDResponse res)
        {
            var x = uw.Command<TEntity>().MapAndSave(t, ref res);
            uw.Save(ref res);
            return x;
        }

        public virtual void Delete(long? id, ref IMDResponse res)
        {
            uw.Command<TEntity>().Delete(id, ref res);
            uw.Save(ref res);
        }
    }
}
